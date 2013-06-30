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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Research.Kinect.Nui;
namespace KinectSkeleton
{
    /// <summary>
    /// This is the main form that hosts the editing and recording utilities.
    /// </summary>
    public partial class MainForm : Form
    {
   

        public MainForm()
        {
            InitializeComponent();
            SkeletonKinectManager.Instance.SkeletonReady += Instance_SkeletonReady;
            app.RecentFiles.Load();
        }

        void Instance_SkeletonReady(object sender, SkeletonEventArgs e)
        {
            skeletonView1.DrawSnapshot(e.Snapshot);
        }


        private void buttonRecord_Click(object sender, EventArgs e)
        {
            ProcessRecord.ToggleRecord(app);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            ProcessPlay.TogglePlay(app);
        }
       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessNew.New(app);
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            ProcessOpen.Open(this.app);
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            ProcessSave.Save(this.app);
        }

        /// <summary>
        /// Shows the about dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessAbout.About(app);
        }

        private void playSlider_PlayPositionChanged(object sender, EventArgs e)
        {
            app.AnimationManager.PlayPosition = playSlider.Value;
        }

        private void playSlider_SelectionChanged(object sender, EventArgs e)
        {
            if (playSlider.Selected)
            {
                menuCut.Enabled = true;
                
                menuDelete.Enabled = true;
            }
            else {
                menuCut.Enabled = false;
                menuDelete.Enabled = false;
            }
        }

       
        private void menuDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("https://kinectskeletonrecorder.codeplex.com/documentation");
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            ActionCopy copy = new ActionCopy(app);
            copy.Run();
        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

      

       
    }
}
