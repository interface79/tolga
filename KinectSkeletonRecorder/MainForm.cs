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
        private bool recording;

        public MainForm()
        {
            InitializeComponent();
            AnimationManager.Instance.PlayEnded += Animation_PlayEnded;
            AnimationManager.Instance.SkeletonReady += Animation_SkeletonReady;
            SkeletonKinectManager.Instance.SkeletonReady += Instance_SkeletonReady;
        }

        void Instance_SkeletonReady(object sender, SkeletonEventArgs e)
        {
            skeletonView1.DrawSnapshot(e.Snapshot);
        }

        void Animation_SkeletonReady(object sender, SkeletonEventArgs e)
        {
            skeletonView1.DrawSnapshot(e.Snapshot);
            playSlider.Value = AnimationManager.Instance.PlayPosition;
        }

        

        void Animation_PlayEnded(object sender, EventArgs e)
        {
            buttonPlay.Image = Properties.Resources.play32;
            buttonPlay.Text = "Play";
            toolTipHelp.SetToolTip(buttonPlay, "Press to begin playing back the skeleton frames one frame at a time.");
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                AnimationManager.Instance.CurrentAnimation = new SkeletonAnimation();
                SkeletonKinectManager.Instance.Start();
                
                buttonRecord.Image = Properties.Resources.stop32;
                buttonRecord.Text = "Stop";
                toolTipHelp.SetToolTip(buttonRecord, "Press to stop recording skeleton snapshots from the kinect.");
                recording = true;
            }
            else {
                buttonRecord.Image = Properties.Resources.record321;
                buttonRecord.Text = "Record";
                toolTipHelp.SetToolTip(buttonRecord, "Press to start recording skeleton snapshots from the kinect.");
                SkeletonKinectManager.Instance.Stop(); 
                buttonPlay.Enabled = true;
                playSlider.Enabled = true;
                playSlider.Maximum = AnimationManager.Instance.CurrentAnimation.Snapshots.Count - 1;
                playSlider.Minimum = 0;
                recording = false;
            }
            
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!AnimationManager.Instance.Playing)
            {
                AnimationManager.Instance.Start();
                buttonPlay.Image = Properties.Resources.stop32;
                buttonPlay.Text = "Stop";
                toolTipHelp.SetToolTip(buttonPlay, "Press to stop playing back the skeleton frames.");
            }
            else {
                AnimationManager.Instance.Stop();
                buttonPlay.Image = Properties.Resources.play32;
                buttonPlay.Text = "Play";
                toolTipHelp.SetToolTip(buttonPlay, "Press to begin playing back the skeleton frames one frame at a time.");
            }
        }
       
       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnimationManager.Instance.CurrentAnimation = new SkeletonAnimation();
            buttonPlay.Enabled = false;
            playSlider.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAction.Open(this);
            if(AnimationManager.Instance.CurrentAnimation != null){
                buttonPlay.Enabled = true;
                playSlider.Enabled = true;
                playSlider.Maximum = AnimationManager.Instance.SnapshotCount - 1;
                playSlider.Value = 0;
                Text = AnimationManager.Instance.CurrentAnimation.Name;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAction.Save(this);
            if (AnimationManager.Instance.CurrentAnimation != null) {
                this.Text = AnimationManager.Instance.CurrentAnimation.Name;
            }
            
        }

        /// <summary>
        /// Shows the about dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog(this);
        }

        private void playSlider_PlayPositionChanged(object sender, EventArgs e)
        {
            AnimationManager.Instance.PlayPosition = playSlider.Value;
        }

        private void playSlider_SelectionChanged(object sender, EventArgs e)
        {
            if (playSlider.Selected)
            {
                buttonDelete.Enabled = true;
            }
            else {
                buttonDelete.Enabled = false;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int start = playSlider.SelectionStart;
            int end = playSlider.SelectionEnd;
            AnimationManager.Instance.CurrentAnimation.Snapshots.RemoveRange(start, end - start);
            playSlider.Selected = false;
            playSlider.Maximum = AnimationManager.Instance.CurrentAnimation.Snapshots.Count;
            if (playSlider.Value > playSlider.Maximum) {
                playSlider.Value = playSlider.Maximum;
            }

        }

       
    }
}
