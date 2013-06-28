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
        private SelectableSlider _parentSlider;
        
        [Description("Gets or sets the SelectableSlider control that this context menu belongs to.")]
        public SelectableSlider ParentSlider {
            get { return _parentSlider; }
            set
            {
                if (_parentSlider != null) {
                    _parentSlider.MouseDown -= ParentSlider_MouseDown;
                }
                _parentSlider = value;
                _parentSlider.MouseDown += ParentSlider_MouseDown;
            }
        }

        void ParentSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Right) == System.Windows.Forms.MouseButtons.Right) {
                this.Show(ParentSlider, e.Location);
            }
        }

        public SliderContextMenu() {
            
           
            ToolStripMenuItem copy = new ToolStripMenuItem("Copy", Properties.Resources.Copy16);
            copy.Click += Copy_Click;
            this.Items.Add(copy);

            ToolStripMenuItem paste = new ToolStripMenuItem("Paste", Properties.Resources.Paste16);
            paste.Click += Paste_Click;
            this.Items.Add(paste);

            ToolStripMenuItem delete = new ToolStripMenuItem("Delete", Properties.Resources.Delete16);
            delete.Click += Delete_Click;
            this.Items.Add(delete);
        }

        void Delete_Click(object sender, EventArgs e) {
            if (!ParentSlider.Selected)
            {
                MessageBox.Show("No frames have been selected to delete.  First drag a selection rectangle on the slider.");
               
            }
            else
            {
                // If a selection exists, replace it with the copied content.
                int count = ParentSlider.SelectionEnd - ParentSlider.SelectionStart;
                AnimationManager.Instance.CurrentAnimation.Snapshots.RemoveRange(ParentSlider.SelectionStart, count);
                ParentSlider.Maximum = AnimationManager.Instance.SnapshotCount;
                if (ParentSlider.Value > ParentSlider.Maximum)
                {
                    ParentSlider.Value = ParentSlider.Maximum;
                }
                ParentSlider.Selected = false;
            }
            Close();
        }

        void Paste_Click(object sender, EventArgs e)
        {
            if (AnimationManager.Instance.ClipboardAnimation == null)
            {
                MessageBox.Show("The clipboard is empty.  First select a region by dragging a rectangle on the slider, and then copy the selection using the context menu.");

            }
            else
            {
                int start;
 
                if (!ParentSlider.Selected)
                {
                    // we can paste where the value is if there is no selection
                    start = ParentSlider.Value;
                    
                }
                else
                {
                    // If a selection exists, replace it with the copied content.
                    start = ParentSlider.SelectionStart;
                    int count = ParentSlider.SelectionEnd - ParentSlider.SelectionStart;
                    AnimationManager.Instance.CurrentAnimation.Snapshots.RemoveRange(start, count);
                }
                
                AnimationManager.Instance.PasteFromClipboard(start);
                ParentSlider.SelectionStart = start;
                ParentSlider.SelectionEnd = start + AnimationManager.Instance.ClipboardAnimation.Snapshots.Count;
                ParentSlider.Selected = true;
                ParentSlider.Maximum = AnimationManager.Instance.SnapshotCount;
                if (ParentSlider.Value > ParentSlider.Maximum)
                {
                    ParentSlider.Value = ParentSlider.Maximum;
                }
            }
            Close();

        }

        void Copy_Click(object sender, EventArgs e)
        {
            if (!ParentSlider.Selected)
            {
                MessageBox.Show("Please select the frames to copy on the slider by dragging a rectangle before attempting to copy.");

            }
            else {
                int count = ParentSlider.SelectionEnd - ParentSlider.SelectionStart;
                AnimationManager.Instance.CopyToClipboard(ParentSlider.SelectionStart, count);
                
            }
            Close();
        }
    }
}
