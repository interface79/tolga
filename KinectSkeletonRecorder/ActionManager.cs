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
 * The initial version of this file was created on 6/29/2013 3:12:02 PM
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
    /// The ActionLogger class
    /// </summary>
    public class ActionManager
    {
        #region Fields

        /// <summary>
        /// The index of the current action in the undo chain.
        /// </summary>
        private int _currentIndex;

        private ApplicationManager _app;

        #endregion

        #region Events

        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the ActionLogger class.
        /// </summary>
        public ActionManager(ApplicationManager app)
        {
            _app = app;
            Actions = new List<Action>();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Causes the current action to perform itself and adds the change to the undo list, and advances the current index
        /// to that value.  This will also clear any "redo" content that is higher in the list that the current index.
        /// </summary>
        /// <param name="action"></param>
        public void Add(Action action)
        {
            if (_currentIndex < Actions.Count - 1)
            {
                Actions.RemoveRange(_currentIndex + 1, Actions.Count - (_currentIndex + 1));
            }
            Actions.Add(action);
            _currentIndex = Actions.Count - 1;
        }

        /// <summary>
        /// Causes the last Action to undo itself.  This also moves the current index back by one.
        /// </summary>
        public void Undo()
        {
            if (Actions.Count > 0 && _currentIndex > 0)
            {
                Actions[_currentIndex].Undo();
                _currentIndex--;
            }
        }

        /// <summary>
        /// Invokes the redo for the action, which uses the stored parameters from the initial entry.
        /// This also advances the current index one notch in the ActionHistory so long as there
        /// is an action to redo.
        /// </summary>
        public void Redo()
        {
            if (Actions.Count - 1 > _currentIndex)
            {
                _currentIndex++;
                Actions[_currentIndex].Redo();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The list of undo/redo actions that have been performed in the past.
        /// </summary>
        public List<Action> Actions { get; private set; }

        #endregion




    }
}
