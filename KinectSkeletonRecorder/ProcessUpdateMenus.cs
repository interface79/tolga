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
 * The initial version of this file was created on 6/30/2013 11:29:24 AM
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
    /// The ProcessUpdateEnabling class
    /// </summary>
    public class ProcessUpdateMenus : IProcess
    {


        #region Methods

        /// <summary>
        /// This method handles in one location the conditionality for enabling menus.  Any event that might change
        /// these conditions should then call this method to update the GUI.
        /// </summary>
        /// <param name="app"></param>
        public void Run(ApplicationManager app) {
            UpdatePasteEnabled(app);
            UpdateSelectAllEnabled(app);
            UpdateUndoMenus(app);
            UpdateCopyCutDel(app);
            UpdatePlay(app);
            UpdateSave(app);
            if (app.AnimationManager.CurrentAnimation != null) {
                if (app.MainForm != null) {
                    string text = app.AnimationManager.CurrentAnimation.Name;
                    if (app.Changed) {
                        text += "*";
                    }
                    app.MainForm.Text = text;
                }
            }
        }

        private void UpdateSave(ApplicationManager app) {
            ToolStripMenuItem save = app.GetMenu("menuSave");
            save.Enabled = app.ProcessSave.IsEnabled(app);
            ToolStripMenuItem saveas = app.GetMenu("menuSaveAs");
            saveas.Enabled = app.ProcessSaveAs.IsEnabled(app);
        }
       

        /// <summary>
        /// Update Menus is always enabled.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public bool IsEnabled(ApplicationManager app)
        {
            return true;
        }

        private void UpdatePlay(ApplicationManager app) {
            if (app.ProcessPlay != null) {
                if (app.ButtonPlay != null) {
                    app.ButtonPlay.Enabled = app.ProcessPlay.IsEnabled(app);
                }
            }
        }




        public void UpdateCopyCutDel(ApplicationManager app){
            if (app != null)
            {
                if (app.Slider != null) {
                    bool selected = app.Slider.Selected;
                    ToolStripMenuItem cut = app.GetMenu("menuCut");
                    if (cut != null)
                    {
                        cut.Enabled = selected;
                    }
                    ToolStripMenuItem del = app.GetMenu("menuDelete");
                    if (del != null)
                    {
                        del.Enabled = selected;
                    }
                    ToolStripMenuItem copy = app.GetMenu("menuCopy");
                    if (copy != null)
                    {
                        copy.Enabled = selected;
                    }
                    if (app.SliderContextMenu != null)
                    {
                        app.SliderContextMenu.Copy.Enabled = selected;
                        app.SliderContextMenu.Delete.Enabled = selected;
                        app.SliderContextMenu.Cut.Enabled = selected;
                    }

                }
                
            }
        }
        



        /// <summary>
        /// Updates the enabled states based on teh states of this manager.
        /// </summary>
        private void UpdateUndoMenus(ApplicationManager app)
        {
            if (app != null)
            {
                ToolStripMenuItem menuUndo = app.GetMenu("menuUndo");
                if (menuUndo != null)
                {
                    menuUndo.Enabled = (app.ActionManager.Actions != null && app.ActionManager.Actions.Count > 0 && app.ActionManager.CurrentIndex > 0);
                }

                ToolStripMenuItem menuRedo = app.GetMenu("menuRedo");
                if (menuRedo != null)
                {
                    menuRedo.Enabled = (app.ActionManager.CurrentIndex < app.ActionManager.Actions.Count - 1);
                }
            }
        }

        private void UpdateSelectAllEnabled(ApplicationManager app) {
            if (app != null) {
                bool selectEnabled = app.ProcessSelectAll.IsEnabled(app);
                ToolStripMenuItem menuSelect = app.GetMenu("menuSelectAll");
                if (menuSelect != null)
                {
                    menuSelect.Enabled = selectEnabled;
                }
            }
        }

        /// <summary>
        /// The enabled state of the "Paste" menu items depend on whether or not the clipboard has content.
        /// </summary>
        private void UpdatePasteEnabled(ApplicationManager app)
        {
            if (app.AnimationManager != null)
            {
                bool pasteEnabled = (app.AnimationManager.ClipboardAnimation != null && app.AnimationManager.ClipboardAnimation.Snapshots != null &&
                        app.AnimationManager.ClipboardAnimation.Snapshots.Count > 0);
                ToolStripMenuItem menuPaste = app.GetMenu("menuPaste");
                if (menuPaste != null)
                {
                    menuPaste.Enabled = pasteEnabled;
                }
                if (app.SliderContextMenu != null)
                {
                    app.SliderContextMenu.Paste.Enabled = pasteEnabled;
                }
            }
           

        }


        #endregion


    }
}
