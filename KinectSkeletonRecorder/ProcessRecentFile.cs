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
 * The initial version of this file was created on 6/30/2013 4:49:32 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectSkeleton
{
    /// <summary>
    /// The RecentFileProcess class
    /// </summary>
    public class ProcessRecentFile : IProcess
    {
        #region Fields

        #endregion

        #region Events

        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the RecentFileProcess class.
        /// </summary>
        public ProcessRecentFile()
        {
        }


        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion



        public void Run(ApplicationManager app)
        {
            string filename = Properties.Settings.Default.RecentFile;
            
            if(!File.Exists(filename)){
                return;
            }
            SkeletonAnimation animation = new SkeletonAnimation();
            animation.Open(filename);
            app.AnimationManager.CurrentAnimation = animation;
            if (app.AnimationManager.Playing)
            {
                app.TogglePlay();
            }
            if (string.IsNullOrEmpty(app.AnimationManager.CurrentAnimation.Name))
            {
                animation.Name = Path.GetFileNameWithoutExtension(filename);
            }
            animation.Filename = filename;
            if (app.AnimationManager.CurrentAnimation != null)
            {
                if (app.ButtonPlay != null)
                {
                    app.ButtonPlay.Enabled = true;
                }
                if (app.Slider != null)
                {
                    app.Slider.Enabled = true;
                    app.Slider.Maximum = app.AnimationManager.SnapshotCount - 1;
                    app.Slider.Value = 0;

                }
                if (app.MainForm != null)
                {
                    app.MainForm.Text = app.AnimationManager.CurrentAnimation.Name;
                }
      
                ToolStripMenuItem menuSelect = app.GetMenu("menuSelectAll");
                if (menuSelect != null)
                {
                    menuSelect.Enabled = (app.AnimationManager.CurrentAnimation.Snapshots.Count > 0);
                }
                if (app.Viewer != null)
                {
                    if (app.AnimationManager.CurrentAnimation != null && app.AnimationManager.CurrentAnimation.Snapshots != null &&
                        app.AnimationManager.CurrentAnimation.Snapshots.Count > 0)
                    {
                        app.Viewer.DrawSnapshot(app.AnimationManager.CurrentAnimation.Snapshots[0]);
                    }

                }

            }
            app.Changed = false;
            app.ActionManager.Actions.Clear();
            app.UpdateMenus();
        }

        public bool IsEnabled(ApplicationManager app)
        {
            return true;
        }
    }
}
