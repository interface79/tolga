/**
 * The MIT License (MIT)
 * Copyright (c) 2013 Harold Dunsford Jr.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to deal 
 * in the Software without restriction, including without limitation the rights 
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Research.Kinect.Nui;
using Microsoft.Research.Kinect.Audio;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
namespace KinnectTest
{
    /// <summary>
    /// This is not required for the skeleton recording, but can be used if image recording is desired instead.
    /// </summary>
    public class ImageKinectManager
    {

        #region Singleton

        public static ImageKinectManager _instance;

        /// <summary>
        /// As part of the singleton pattern, this creates the single instance of this class.
        /// </summary>
        public static ImageKinectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImageKinectManager();
                }
                return _instance;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The event to be fired.
        /// </summary>
        public event EventHandler<ImageEventArgs> ImageReady;

        /// <summary>
        /// This fires the ImageReady event, and provides a pathway for overriding in subclasses.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnImageReady(ImageEventArgs e)
        {
            if (ImageReady != null)
            {
                ImageReady(this, e);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts providing images from kinect.
        /// </summary>
        public void Start()
        {
            Runtime nui = Runtime.Kinects[0];
            nui.Initialize(RuntimeOptions.UseColor);
            nui.VideoStream.Open(
              ImageStreamType.Video, 2,
              ImageResolution.Resolution640x480,
              ImageType.Color);
            nui.VideoFrameReady += VideoFrameReady;
            
        }

        /// <summary>
        /// Stops providing images from kinect.
        /// </summary>
        public void Stop() {
            Runtime nui = Runtime.Kinects[0];
            nui.Uninitialize();
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// This event handler is called by the nui kinect controler.
        /// </summary>
        /// <param name="sender">The obejct sender</param>
        /// <param name="e">An ImageFrameReadyEventArgs with all the information about the raw image data from the Kinect.</param>
        private void VideoFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            PlanarImage rawImage = e.ImageFrame.Image;
            Bitmap bmp = PImageToBitmap(rawImage);
            OnImageReady(new ImageEventArgs(bmp));
           
        }

        /// <summary>
        /// The PlanarImage objects returned from Kinect are not exactly the same as Bitmap objects, so in order to work with the 
        /// images using standard GDI+, this method converts the planar image into a bitmap.
        /// </summary>
        /// <param name="PImage">The PlanarImage object returned from the Kinect</param>
        /// <returns>The Bitmap object</returns>
        private Bitmap PImageToBitmap(PlanarImage PImage)
        {
            Bitmap bmap = new Bitmap( PImage.Width, PImage.Height, PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, PImage.Width, PImage.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(PImage.Bits, 0, ptr, PImage.Width * PImage.BytesPerPixel * PImage.Height);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        #endregion

    }
}
