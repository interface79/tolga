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
 * The initial version of this file was created on 6/29/2013 6:26:37 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectSkeleton
{
    /// <summary>
    /// The ProcessRecord class
    /// </summary>
    public class ProcessRecord : IProcess
    {
        #region Fields

        


        #endregion

        #region Methods

        /// <summary>
        /// This will either start recording or stop recording, depending on whether the application is actively recording.
        /// </summary>
        /// <param name="app"></param>
        public void Run(ApplicationManager app) {
            if (!app.Recording)
            {
                //  .AnimationManager.Instance.CurrentAnimation = new SkeletonAnimation();
                bool started = SkeletonKinectManager.Instance.Start();
                if (!started) {
                    return;
                }
                if (app.ButtonRecord != null) {
                    app.ButtonRecord.Image = Properties.Resources.stop32;
                    app.ButtonRecord.Text = Messages.ProcessRecord_Stop;
                    if (app.ToolTip != null)
                    {
                        app.ToolTip.SetToolTip(app.ButtonRecord, Messages.ProcessRecord_PressStop);
                    }
                }
                app.Recording = true;
            }
            else
            {
                if (app.ButtonRecord != null)
                {
                    app.ButtonRecord.Image = Properties.Resources.record321;
                    app.ButtonRecord.Text = Messages.ProcessRecord_Record;
                    if (app.ToolTip != null)
                    {
                        app.ToolTip.SetToolTip(app.ButtonRecord, Messages.ProcessRecord_PressRecord);
                    }
                }
                
                SkeletonKinectManager.Instance.Stop();
                if (app.ButtonPlay != null) {
                    app.ButtonPlay.Enabled = true;
                }
                if (app.Slider != null) {
                    app.Slider.Enabled = true;
                    if (app.AnimationManager.CurrentAnimation != null && app.AnimationManager.CurrentAnimation.Snapshots != null &&
                        app.AnimationManager.CurrentAnimation.Snapshots.Count > 0) {
                            app.Slider.Maximum = app.AnimationManager.CurrentAnimation.Snapshots.Count - 1;
                    }
                    app.Slider.Minimum = 0;
                }
                ToolStripMenuItem menuSelect = app.GetMenu("menuSelectAll");
                if (menuSelect != null)
                {
                    menuSelect.Enabled = (app.AnimationManager.CurrentAnimation.Snapshots.Count > 0);
                }
                app.Recording = false;
            }
            
        
        }

        /// <summary>
        /// Record is always enabled.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public bool IsEnabled(ApplicationManager app) {
            return true;
        }

        #endregion

    }
}
