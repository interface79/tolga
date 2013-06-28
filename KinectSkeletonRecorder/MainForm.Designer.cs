﻿/**
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
namespace KinectSkeleton
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.playSlider = new KinectSkeleton.SelectableSlider();
            this.skeletonView1 = new KinectSkeleton.SkeletonView();
            this.sliderContextMenu1 = new KinectSkeleton.SliderContextMenu();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(586, 24);
            this.menuMain.TabIndex = 5;
            this.menuMain.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.documentationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::KinectSkeleton.Properties.Resources.Delete32;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(444, 42);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 40);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete Selection";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHelp.SetToolTip(this.buttonDelete, "This will delete the range selected on the slider.");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Image = global::KinectSkeleton.Properties.Resources.play32;
            this.buttonPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.Location = new System.Drawing.Point(106, 42);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 40);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHelp.SetToolTip(this.buttonPlay, "Press to begin playing back kinect data.");
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Image = global::KinectSkeleton.Properties.Resources.record321;
            this.buttonRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRecord.Location = new System.Drawing.Point(12, 42);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(88, 40);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHelp.SetToolTip(this.buttonRecord, "Press to begin recording Kinect data.");
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // playSlider
            // 
            this.playSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playSlider.Enabled = false;
            this.playSlider.Location = new System.Drawing.Point(196, 42);
            this.playSlider.Maximum = 100;
            this.playSlider.Minimum = 0;
            this.playSlider.Name = "playSlider";
            this.playSlider.Selected = false;
            this.playSlider.SelectedColor = System.Drawing.Color.LightBlue;
            this.playSlider.SelectionEnd = 0;
            this.playSlider.SelectionStart = 0;
            this.playSlider.Size = new System.Drawing.Size(233, 45);
            this.playSlider.SliderColor = System.Drawing.Color.Blue;
            this.playSlider.TabIndex = 6;
            this.playSlider.Text = "selectableSlider1";
            this.toolTipHelp.SetToolTip(this.playSlider, "Move the slider to see the animation frame, or select a region by drawing a recta" +
        "ngle on the slider.");
            this.playSlider.TrackColor = System.Drawing.Color.Green;
            this.playSlider.Value = 50;
            this.playSlider.ValueChanged += new System.EventHandler(this.playSlider_PlayPositionChanged);
            this.playSlider.SelectionChanged += new System.EventHandler(this.playSlider_SelectionChanged);
            // 
            // skeletonView1
            // 
            this.skeletonView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skeletonView1.BackColor = System.Drawing.Color.White;
            this.skeletonView1.Location = new System.Drawing.Point(0, 93);
            this.skeletonView1.Name = "skeletonView1";
            this.skeletonView1.Size = new System.Drawing.Size(586, 301);
            this.skeletonView1.TabIndex = 0;
            this.skeletonView1.Text = "skeletonView1";
            // 
            // sliderContextMenu1
            // 
            this.sliderContextMenu1.Name = "sliderContextMenu1";
            this.sliderContextMenu1.ParentSlider = this.playSlider;
            this.sliderContextMenu1.Size = new System.Drawing.Size(108, 70);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 394);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.playSlider);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.skeletonView1);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SkeletonView skeletonView1;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private SelectableSlider playSlider;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private SliderContextMenu sliderContextMenu1;



    }
}

