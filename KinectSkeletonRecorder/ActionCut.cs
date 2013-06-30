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
 * The initial version of this file was created on 6/29/2013 1:58:09 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectSkeleton
{
    /// <summary>
    /// The ActionCut class
    /// </summary>
    public class ActionCut : Action
    {
        #region Fields

        private ApplicationManager _app;

        #endregion

        #region Events

        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the ActionCut class.
        /// </summary>
        public ActionCut(ApplicationManager app)
        {
            _app = app;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Uses the slider control to begin the cut process, assuming a selection exists.
        /// </summary>
        public void Run()
        {
            if (_app.Slider == null || !_app.Slider.Selected)
            {
                return;
            }
            _app.ActionManager.Add(this);
            OldSnapshots = _app.AnimationManager.CurrentAnimation.Snapshots;
            Start = _app.Slider.SelectionStart;
            Count = _app.Slider.SelectionEnd - Start;
            Snapshots = _app.AnimationManager.CurrentAnimation.Snapshots.GetRange(Start, Count);
            Redo();
        }

        public void Redo()
        {
            _app.AnimationManager.ClipboardAnimation.Snapshots = Snapshots;
            _app.AnimationManager.CurrentAnimation.Snapshots.RemoveRange(Start, Count);
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            _app.Slider.Selected = false;
            _app.Slider.Value = Start;
            _app.Changed = true;
            _app.UpdateMenus();
            
        }

        public void Undo()
        {
            _app.AnimationManager.ClipboardAnimation.Snapshots = OldSnapshots;
            _app.AnimationManager.CurrentAnimation.Snapshots.InsertRange(Start, Snapshots);
            _app.Slider.Maximum = _app.AnimationManager.SnapshotCount;
            _app.Slider.Selected = true;
            _app.Slider.SelectionStart = Start;
            _app.Slider.SelectionEnd = Start + Count;
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
        /// Gets or sets the list of snapshots that were cleared from the clipboard by this action.
        /// </summary>
        public List<SkeletonSnapshot> OldSnapshots { get; protected set; }

        /// <summary>
        /// Gets or sets the start index for the delete action.  This is read auotmatically from the control in the do method.
        /// </summary>
        public int Start { get; protected set; }

        #endregion



        
    }
}
