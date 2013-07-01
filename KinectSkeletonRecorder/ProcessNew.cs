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
 * The initial version of this file was created on 6/29/2013 6:50:46 PM
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
    /// The ProcessNew class
    /// </summary>
    public class ProcessNew : IProcess
    {

        #region Methods

        /// <summary>
        /// This process clears any content currently in the animation manager
        /// </summary>
        /// <param name="app"></param>
        public void Run(ApplicationManager app) {
            app.AnimationManager.CurrentAnimation = new SkeletonAnimation();
            app.AnimationManager.CurrentSnapshot = null;
            if (app.MainForm != null) { 
                app.MainForm.Text = null;
            }
            if (app.ButtonPlay != null) {
                app.ButtonPlay.Enabled = false;
            }
            if (app.Slider != null) {
                app.Slider.Enabled = false;
                app.Slider.Selected = false;
                app.Slider.Value = 0;
                app.Slider.Refresh();
                app.Slider.Invalidate();
            }
            if (app.Viewer != null) {
                app.Viewer.Clear();
                
            }
            app.ActionManager.Actions.Clear();
           
        }

        /// <summary>
        /// New is always enabled.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public bool IsEnabled(ApplicationManager app)
        {
            return true;
        }

        #endregion




    }
}
