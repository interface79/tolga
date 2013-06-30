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
 * The initial version of this file was created on 6/29/2013 6:43:06 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectSkeleton
{
    /// <summary>
    /// The ProcessPlay class
    /// </summary>
    public class ProcessPlay
    {
        

        #region Methods

        /// <summary>
        /// This method will toggle the animation manager's playing back of the animation in the viewer.
        /// If the various buttons are being used, then this will toggle the play button configuration.
        /// </summary>
        /// <param name="app"></param>
        public static void TogglePlay(ApplicationManager app) {
            if (!app.AnimationManager.Playing)
            {
                app.AnimationManager.Start();
                if (app.ButtonPlay != null) {
                    app.ButtonPlay.Image = Properties.Resources.stop32;
                    app.ButtonPlay.Text = Messages.ProcessPlay_Stop;
                    if (app.ToolTip != null) {
                        app.ToolTip.SetToolTip(app.ButtonPlay, Messages.ProcessPlay_PressStop);
                    }
                }
            }
            else
            {
                app.AnimationManager.Stop();
                if (app.ButtonPlay != null) {
                    app.ButtonPlay.Image = Properties.Resources.play32;
                    app.ButtonPlay.Text = Messages.ProcessPlay_Play;
                    if (app.ToolTip != null)
                    {
                        app.ToolTip.SetToolTip(app.ButtonPlay, Messages.ProcessPlay_PressPlay);
                    }
                }
            }
        
        }

        #endregion



    }
}
