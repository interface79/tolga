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
 * The initial version of this file was created on 6/29/2013 9:47:46 AM
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
    /// The ActionPaste class
    /// </summary>
    public class ActionPaste : Action
    {

        #region Fields

        ApplicationManager _app;
        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the ActionPaste class.
        /// </summary>
        public ActionPaste(ApplicationManager app)
        {
            _app = app;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Implements the initial paste action, locking in the Start and Count properties from the selection.
        /// This also adds this new action to the ActionManager.  Then this method hands off the process
        /// to the Redo method which implements the business logic.
        /// </summary>
        public void Run()
        {
            if (_app.AnimationManager.ClipboardAnimation.Snapshots == null ||
                _app.AnimationManager.ClipboardAnimation.Snapshots.Count == 0)
            {
                MessageBox.Show(_app.MainForm, Messages.ActionPaste_EmptyClipbaordText, Messages.ActionPaste_InvalidAction, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_app.Slider == null) {
                return;
            }
            //ActionManager.Instance.Add(this);
            Start = _app.Slider.Value;
            Snapshots = _app.AnimationManager.ClipboardAnimation.Snapshots;
            Count = Snapshots.Count;
            Redo();
        }

        /// <summary>
        /// Redo implements the business logic, and can be re-implemented directly as a part of an undo/redo stack.
        /// </summary>
        public void Redo() {
            _app.AnimationManager.PasteFromClipboard(Start);
            _app.Slider.Selected = false;
            _app.Slider.Value = Start + Count;
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            _app.Changed = true;
            _app.UpdateMenus();
        }

        /// <summary>
        /// The undo sequence implements the business logic for reversing the action.
        /// </summary>
        public void Undo() {
            _app.AnimationManager.CurrentAnimation.Snapshots.RemoveRange(Start, Count);
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            _app.Slider.Selected = false;
            _app.Slider.Value = Start;
            _app.Changed = true;
            _app.UpdateMenus();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the end index for the delete action.  This is read automatically from the control in the do method.
        /// </summary>
        public int Count { get; protected set; }


        /// <summary>
        /// Get or sets the list of snapshots that were deleted by this action.
        /// </summary>
        public List<SkeletonSnapshot> Snapshots { get; protected set; }

        /// <summary>
        /// Gets or sets the start index for the delete action.  This is read auotmatically from the control in the do method.
        /// </summary>
        public int Start { get; protected set; }

        #endregion


    }
}
