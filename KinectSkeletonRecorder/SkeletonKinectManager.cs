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
using System.Windows.Forms;

namespace KinnectTest
{
    /// <summary>
    /// This is a singleton manager to interact with the kinect sensor.  The Start and Stop methods activate and deactivate the
    /// events that will be fired providing skeleton bodies.
    /// </summary>
    public class SkeletonKinectManager
    {
        #region events

        /// <summary>
        /// An event that is fired once a Skeleton has been created.
        /// </summary>
        public event EventHandler<SkeletonEventArgs> SkeletonReady;

        /// <summary>
        /// This method raises the SkeletonReady event, and provides an
        /// overrideable method for subclasses to change.
        /// </summary>
        /// <param name="e">The SkeletonEventArgs that contains all the information about the tracked skeletons for a single frame.</param>
        protected virtual void OnSkeletonReady(SkeletonEventArgs e)
        {
            if (SkeletonReady != null)
            {
                SkeletonReady(this, e);
            }
        }

        #endregion

        #region Singleton

        /// <summary>
        /// As part of the singleton pattern, this is the single instance of the kinect
        /// </summary>
        public static SkeletonKinectManager _instance;

       

        /// <summary>
        /// Gets the static instance of Kinnect
        /// </summary>
        public static SkeletonKinectManager Instance
        {
            get {
                if (_instance == null) {
                    _instance = new SkeletonKinectManager();
                }
                return _instance;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts recording skeletons.  Events are only fired if there is a tracked skeleton.
        /// </summary>
        public void Start()
        {
            
            try
            {
                Runtime nui = Runtime.Kinects[0];
                nui.Initialize(RuntimeOptions.UseSkeletalTracking);
                nui.SkeletonFrameReady += SkeletonFrameReady;
            }
            catch (Exception) {
                MessageBox.Show("The Kinect sensor either is not connected or is not currently enabled.");
            }
            
            
        }

        /// <summary>
        /// Stops skeleton tracking.
        /// </summary>
        public void Stop() {
            Runtime nui = Runtime.Kinects[0];
            nui.Uninitialize();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This handler is responsible for converting the SkeletonFrameReadyEventArgs into a serializable SkeletonBody
        /// that can be added to the recording.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            // A SkeletonFrame object will provide multiple skeletons.
            SkeletonFrame allSkeletons = e.SkeletonFrame;

            // The skeletons list selects the skeletons that are tracked, but does not bother with the others.
            List<SkeletonData> skeletons = new List<SkeletonData>((from s in allSkeletons.Skeletons
                                     where s.TrackingState == SkeletonTrackingState.Tracked
                                     select s));
            
            
            
            // Only throw an event if we are actively tracking at least one skeleton.
            if (skeletons != null && skeletons.Count > 0) {
                // A SkeletonSnapshot represents multiple instances.
                SkeletonSnapshot snapshot = new SkeletonSnapshot(skeletons);
                
                this.SkeletonReady(this, new SkeletonEventArgs(snapshot));
            }
        }

        #endregion


    }
}
