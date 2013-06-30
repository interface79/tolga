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
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panelSlider = new System.Windows.Forms.Panel();
            this.skeletonView1 = new KinectSkeleton.SkeletonView();
            this.playSlider = new KinectSkeleton.SelectableSlider();
            this.app = new KinectSkeleton.ApplicationManager();
            this.sliderContextMenu1 = new KinectSkeleton.SliderContextMenu();
            this.menuMain.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panelSlider.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(681, 24);
            this.menuMain.TabIndex = 5;
            this.menuMain.Text = "File";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.toolStripSeparator2,
            this.menuSaveAs,
            this.menuSave,
            this.toolStripSeparator3,
            this.menuRecentFiles});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            this.menuFile.ToolTipText = "Clears the current animation and prepares to record new animation content.";
            // 
            // menuNew
            // 
            this.menuNew.Image = global::KinectSkeleton.Properties.Resources.New16;
            this.menuNew.Name = "menuNew";
            this.menuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNew.Size = new System.Drawing.Size(186, 22);
            this.menuNew.Text = "New";
            this.menuNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Image = global::KinectSkeleton.Properties.Resources.Open16;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(186, 22);
            this.menuOpen.Text = "Open";
            this.menuOpen.ToolTipText = "Opens a saved skeleton animation xml file.";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Image = global::KinectSkeleton.Properties.Resources.SaveAs16;
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.menuSaveAs.Size = new System.Drawing.Size(186, 22);
            this.menuSaveAs.Text = "Save As";
            this.menuSaveAs.ToolTipText = "Save the current animation as a new filename.";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSave
            // 
            this.menuSave.Image = global::KinectSkeleton.Properties.Resources.Save16;
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(186, 22);
            this.menuSave.Text = "Save";
            this.menuSave.ToolTipText = "Saves the current animation with it\'s current filename, or saves as if no filenam" +
    "e has been specified.";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // menuRecentFiles
            // 
            this.menuRecentFiles.Name = "menuRecentFiles";
            this.menuRecentFiles.Size = new System.Drawing.Size(186, 22);
            this.menuRecentFiles.Text = "Recent Files";
            this.menuRecentFiles.ToolTipText = "Opens a recently saved or opened animation file.";
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy,
            this.menuCut,
            this.menuDelete,
            this.menuPaste,
            this.menuSelectAll,
            this.toolStripSeparator1,
            this.menuRedo,
            this.menuUndo});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Image = global::KinectSkeleton.Properties.Resources.Copy16;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(164, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.ToolTipText = "Copies the selected slider range to an internal clipboard.  Does not affect the  " +
    "windows clipboard.";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuCut
            // 
            this.menuCut.Enabled = false;
            this.menuCut.Image = global::KinectSkeleton.Properties.Resources.Cut16;
            this.menuCut.Name = "menuCut";
            this.menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuCut.Size = new System.Drawing.Size(164, 22);
            this.menuCut.Text = "Cut";
            this.menuCut.ToolTipText = "Removes the current selection and copies it to the internal clipboard.  This curr" +
    "ently does not copy anything to the Windows clipboard.";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Enabled = false;
            this.menuDelete.Image = global::KinectSkeleton.Properties.Resources.Delete16;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(164, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.ToolTipText = "Removes the animation frames corresponding to the selection on the slider.";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Enabled = false;
            this.menuPaste.Image = global::KinectSkeleton.Properties.Resources.Paste16;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(164, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.ToolTipText = "Pastes the content from the internal clipboard into the image.  If a region is se" +
    "lected, this replaces the selected region.";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuSelectAll.Size = new System.Drawing.Size(164, 22);
            this.menuSelectAll.Text = "Select All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // menuRedo
            // 
            this.menuRedo.Enabled = false;
            this.menuRedo.Image = global::KinectSkeleton.Properties.Resources.Redo16;
            this.menuRedo.Name = "menuRedo";
            this.menuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menuRedo.Size = new System.Drawing.Size(164, 22);
            this.menuRedo.Text = "Redo";
            this.menuRedo.ToolTipText = "Redo one edit action from the undo stack.  This only applies to edit menu actions" +
    ".";
            this.menuRedo.Click += new System.EventHandler(this.menuRedo_Click);
            // 
            // menuUndo
            // 
            this.menuUndo.Enabled = false;
            this.menuUndo.Image = global::KinectSkeleton.Properties.Resources.Undo16;
            this.menuUndo.Name = "menuUndo";
            this.menuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuUndo.Size = new System.Drawing.Size(164, 22);
            this.menuUndo.Text = "Undo";
            this.menuUndo.ToolTipText = "Undoes one edit action.  Only edit actions are added to the undo stack.";
            this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDocumentation,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            // 
            // menuDocumentation
            // 
            this.menuDocumentation.Image = global::KinectSkeleton.Properties.Resources.Help16;
            this.menuDocumentation.Name = "menuDocumentation";
            this.menuDocumentation.Size = new System.Drawing.Size(157, 22);
            this.menuDocumentation.Text = "Documentation";
            this.menuDocumentation.Click += new System.EventHandler(this.menuDocumentation_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Image = global::KinectSkeleton.Properties.Resources.About16;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(157, 22);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Image = global::KinectSkeleton.Properties.Resources.play32;
            this.buttonPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.Location = new System.Drawing.Point(97, 12);
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
            this.buttonRecord.Location = new System.Drawing.Point(3, 12);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(88, 40);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHelp.SetToolTip(this.buttonRecord, "Press to begin recording Kinect data.");
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.skeletonView1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelSlider);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(681, 605);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(681, 630);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // panelSlider
            // 
            this.panelSlider.Controls.Add(this.buttonRecord);
            this.panelSlider.Controls.Add(this.buttonPlay);
            this.panelSlider.Controls.Add(this.playSlider);
            this.panelSlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSlider.Location = new System.Drawing.Point(0, 0);
            this.panelSlider.Name = "panelSlider";
            this.panelSlider.Size = new System.Drawing.Size(681, 71);
            this.panelSlider.TabIndex = 0;
            // 
            // skeletonView1
            // 
            this.skeletonView1.App = null;
            this.skeletonView1.BackColor = System.Drawing.Color.White;
            this.skeletonView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skeletonView1.Location = new System.Drawing.Point(0, 71);
            this.skeletonView1.Name = "skeletonView1";
            this.skeletonView1.Size = new System.Drawing.Size(681, 534);
            this.skeletonView1.TabIndex = 0;
            this.skeletonView1.Text = "skeletonView1";
            // 
            // playSlider
            // 
            this.playSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playSlider.App = this.app;
            this.playSlider.Enabled = false;
            this.playSlider.Location = new System.Drawing.Point(178, 12);
            this.playSlider.Maximum = 100;
            this.playSlider.Minimum = 0;
            this.playSlider.Name = "playSlider";
            this.playSlider.Selected = false;
            this.playSlider.SelectedColor = System.Drawing.Color.LightBlue;
            this.playSlider.SelectionEnd = 0;
            this.playSlider.SelectionStart = 0;
            this.playSlider.Size = new System.Drawing.Size(491, 45);
            this.playSlider.SliderColor = System.Drawing.Color.Blue;
            this.playSlider.TabIndex = 6;
            this.playSlider.Text = "selectableSlider1";
            this.toolTipHelp.SetToolTip(this.playSlider, "Move the slider to see the animation frame, or select a region by drawing a recta" +
        "ngle on the slider.");
            this.playSlider.TrackColor = System.Drawing.Color.Green;
            this.playSlider.Value = 0;
            this.playSlider.ValueChanged += new System.EventHandler(this.playSlider_PlayPositionChanged);
            this.playSlider.SelectionChanged += new System.EventHandler(this.playSlider_SelectionChanged);
            // 
            // app
            // 
            this.app.ButtonPlay = this.buttonPlay;
            this.app.ButtonRecord = this.buttonRecord;
            this.app.MainForm = this;
            this.app.Menu = this.menuMain;
            this.app.Slider = this.playSlider;
            this.app.SliderContextMenu = this.sliderContextMenu1;
            this.app.ToolTip = this.toolTipHelp;
            this.app.Viewer = this.skeletonView1;
            // 
            // sliderContextMenu1
            // 
            this.sliderContextMenu1.App = this.app;
            this.sliderContextMenu1.Name = "sliderContextMenu1";
            this.sliderContextMenu1.Size = new System.Drawing.Size(108, 92);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 654);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panelSlider.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SkeletonView skeletonView1;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private SelectableSlider playSlider;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentation;
        private SliderContextMenu sliderContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuRedo;
        private System.Windows.Forms.ToolStripMenuItem menuUndo;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuRecentFiles;
        private ApplicationManager app;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panelSlider;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;



    }
}

