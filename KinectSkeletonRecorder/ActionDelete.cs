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
 * The initial version of this file was created on 6/29/2013 9:23:07 AM
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
    /// The ActionDelete class
    /// </summary>
    public class ActionDelete : Action
    {
        #region Fields
        private ApplicationManager _app;
        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the ActionDelete class.  This action is desigend to work
        /// strictly with a selectable slider, and so it is required.
        /// </summary>
        public ActionDelete(ApplicationManager app)
        {
            _app = app;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Before implementing the do action, be sure that a selection exists on the slider.
        /// </summary>
        public void Run()
        {
            if (_app.Slider == null || !_app.Slider.Selected)
            {
                MessageBox.Show(_app.MainForm, Messages.ActionDelete_NoSelectionText, Messages.ActionDelete_InvalidAction, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _app.ActionManager.Add(this);
            // If a selection exists, replace it with the copied content.
            Count = _app.Slider.SelectionEnd - _app.Slider.SelectionStart;
            Start = _app.Slider.SelectionStart;
            Snapshots = _app.AnimationManager.CurrentAnimation.Snapshots.GetRange(Start, Count);
            Redo();
        }

        /// <summary>
        /// Redo does not require a selection to be defined, since it was defined before.
        /// </summary>
        public void Redo()
        {
            _app.AnimationManager.CurrentAnimation.Snapshots.RemoveRange(Start, Count);
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            _app.Slider.Selected = false;
            _app.Slider.Value = Start;
        }

        /// <summary>
        /// Undo for delete re-inserts the content.
        /// </summary>
        public void Undo()
        {
            _app.AnimationManager.CurrentAnimation.Snapshots.InsertRange(Start, Snapshots);
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            if (_app.Slider.Value > _app.Slider.Maximum)
            {
                _app.Slider.Value = _app.Slider.Maximum;
            }
            _app.Slider.Selected = true;
            _app.Slider.SelectionStart = Start;
            _app.Slider.SelectionEnd = Start + Count;
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
