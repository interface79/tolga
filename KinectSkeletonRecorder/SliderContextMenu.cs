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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectSkeleton
{
    public class SliderContextMenu : ContextMenuStrip
    {
        private ToolStripMenuItem contextMenuCopy;
        private ToolStripMenuItem contextMenuPaste;
        private ToolStripMenuItem contextMenuCut;
        private ToolStripMenuItem contextMenuDelete;
        private ApplicationManager _app;

       
        void ParentSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Right) == System.Windows.Forms.MouseButtons.Right) {
                this.Show(_app.Slider, e.Location);
            }
        }

        /// <summary>
        /// Creates a new instance of the context menu for the slider that adds the copy, paste and delete functionality
        /// to the slider.
        /// </summary>
        public SliderContextMenu() {
            InitializeComponent();
            contextMenuCopy.Click += Copy_Click;
            contextMenuCut.Click += Cut_Click;
            contextMenuPaste.Click += Paste_Click;
            contextMenuDelete.Click += Delete_Click;
        }



        /// <summary>
        /// This method handles the case when delete is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Delete_Click(object sender, EventArgs e) {
            ActionDelete delete = new ActionDelete(_app);
            delete.Run();
            Close();
        }

        /// <summary>
        /// This method handles the cut context menu item being clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Cut_Click(object sender, EventArgs e){
            ActionCut cut = new ActionCut(_app);
            cut.Run();
            Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Paste_Click(object sender, EventArgs e)
        {
            ActionPaste delete = new ActionPaste(_app);
            delete.Run();
            Close();

        }

        void Copy_Click(object sender, EventArgs e)
        {
            ActionCopy copy = new ActionCopy(_app);
            copy.Run();
            Close();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the optional application manager for this viewer control.  If this is set, then
        /// it enables this tool access to the application for coordinating "linked" actions. 
        /// </summary>
        [Description(" Gets or sets the optional application manager for this viewer control.  If this is set, then " +
            "it enables this tool access to the application for coordinating linked behavior"),
        Category("Behavior")]
        public ApplicationManager App
        {
            get { return _app; }
            set
            {
                if (_app != null)
                {
                    _app.Slider.MouseDown -= ParentSlider_MouseDown;
                }
                _app = value;
                _app.Slider.MouseDown += ParentSlider_MouseDown;
            }
        }

        /// <summary>
        /// Copy menu item
        /// </summary>
        public ToolStripMenuItem Copy { 
            get{
                return contextMenuCopy;
            }
           
        }

        /// <summary>
        /// Paste menu item
        /// </summary>
        public ToolStripMenuItem Paste
        {
            get
            {
                return contextMenuPaste;
            }
        }

        /// <summary>
        /// Cut menu item
        /// </summary>
        public ToolStripMenuItem Cut {
            get
            {
                return contextMenuCut;
            }
        }

        /// <summary>
        /// Delete menu item
        /// </summary>
        public ToolStripMenuItem Delete {
            get
            {
                return contextMenuDelete;
            }
        }
        

        #endregion

        private void InitializeComponent()
        {
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Image = global::KinectSkeleton.Properties.Resources.Copy16;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(107, 22);
            this.contextMenuCopy.Text = "Copy";
            // 
            // contextMenuPaste
            // 
            this.contextMenuPaste.Enabled = false;
            this.contextMenuPaste.Image = global::KinectSkeleton.Properties.Resources.Paste16;
            this.contextMenuPaste.Name = "contextMenuPaste";
            this.contextMenuPaste.Size = new System.Drawing.Size(107, 22);
            this.contextMenuPaste.Text = "Paste";
            // 
            // contextMenuCut
            // 
            this.contextMenuCut.Enabled = false;
            this.contextMenuCut.Image = global::KinectSkeleton.Properties.Resources.Cut16;
            this.contextMenuCut.Name = "contextMenuCut";
            this.contextMenuCut.Size = new System.Drawing.Size(107, 22);
            this.contextMenuCut.Text = "Cut";
            // 
            // contextMenuDelete
            // 
            this.contextMenuDelete.Enabled = false;
            this.contextMenuDelete.Image = global::KinectSkeleton.Properties.Resources.Delete16;
            this.contextMenuDelete.Name = "contextMenuDelete";
            this.contextMenuDelete.Size = new System.Drawing.Size(107, 22);
            this.contextMenuDelete.Text = "Delete";
            // 
            // SliderContextMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy,
            this.contextMenuPaste,
            this.contextMenuCut,
            this.contextMenuDelete});
            this.Size = new System.Drawing.Size(108, 92);
            this.ResumeLayout(false);

        }
    }
}
