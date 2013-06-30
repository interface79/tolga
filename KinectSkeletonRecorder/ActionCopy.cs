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
 * The initial version of this file was created on 6/29/2013 11:55:04 AM
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
    /// The ActionCopy class
    /// </summary>
    public class ActionCopy : Action
    {
        #region Fields

        private ApplicationManager _app;

        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the ActionCopy class.
        /// </summary>
        public ActionCopy(ApplicationManager app)
        {
            _app = app;
        }


        #endregion

        #region Methods

        /// <summary>
        /// This method gathers the initial information from the slider control.  It caches both the
        /// contents of the current clipboard and the new contents.  That way the copy action can be 
        /// undone later.
        /// </summary>
        public void Run()
        {
            if (_app.Slider == null || !_app.Slider.Selected)
            {
                MessageBox.Show(_app.MainForm, Messages.ActionCopy_NoSelectionText, Messages.ActionCopy_InvalidAction, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _app.ActionManager.Add(this);
            OldSnapshots = _app.AnimationManager.CurrentAnimation.Snapshots;
            Start = _app.Slider.SelectionStart;
            Count = _app.Slider.SelectionEnd - Start;
            Snapshots = _app.AnimationManager.CurrentAnimation.Snapshots.GetRange(Start, Count);
            Redo();
        }

        /// <summary>
        /// Redo actually implements the business logic of the copy process from the information stored in this
        /// action.  This can be redone without recieving information.
        /// </summary>
        public void Redo()
        {
            _app.AnimationManager.ClipboardAnimation.Snapshots = Snapshots;
            _app.AnimationManager.UpdatePasteEnabled();
            
        }

        /// <summary>
        /// Undo will replace the original contents to the clipboard, effectively undoing the copy operation.
        /// </summary>
        public void Undo()
        {
            _app.AnimationManager.ClipboardAnimation.Snapshots = OldSnapshots;
            _app.AnimationManager.UpdatePasteEnabled();
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the end index for the delete action.  This is read automatically from the control in the do method.
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// Gets or sets the list of snapshots that were cleared from the clipboard by this action.
        /// </summary>
        public List<SkeletonSnapshot> OldSnapshots { get; protected set; }


        /// <summary>
        /// Get or sets the list of snapshots that were copied to the clipboard by this action.
        /// </summary>
        public List<SkeletonSnapshot> Snapshots { get; protected set; }

        /// <summary>
        /// Gets or sets the start index for the delete action.  This is read auotmatically from the control in the do method.
        /// </summary>
        public int Start { get; protected set; }

        
        #endregion



        
    }
}
