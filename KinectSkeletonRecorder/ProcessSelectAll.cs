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
 * The initial version of this file was created on 6/30/2013 10:56:15 AM
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
    /// The ProcessSelectAll class
    /// </summary>
    public class ProcessSelectAll : IProcess
    {
       

       

        #region Methods

        /// <summary>
        /// Selects the entire range of the slider.
        /// </summary>
        /// <param name="app"></param>
        public void Run(ApplicationManager app) {
            app.Slider.Selected = true;
            app.Slider.SelectionStart = 0;
            app.Slider.SelectionEnd = app.AnimationManager.SnapshotCount;
            app.Slider.OnSelectionChanged(app.Slider, EventArgs.Empty);
        }

        /// <summary>
        /// Gets whether or not this process is enabled
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public bool IsEnabled(ApplicationManager app) {
            if (app.AnimationManager != null)
            {
                return (app.AnimationManager.CurrentAnimation != null && app.AnimationManager.CurrentAnimation.Snapshots != null &&
                    app.AnimationManager.CurrentAnimation.Snapshots.Count > 0);
               
            }
            return false;
        }

        #endregion


    }
}
