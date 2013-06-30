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
 * The initial version of this file was created on 6/29/2013 8:45:27 AM
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
    /// <summary>
    /// This class is a singleton manager responsible for
    /// </summary>
    public class ApplicationManager : Component
    {
        #region Fields

        #endregion

        /// <summary>
        /// Creates a new instance of the ActionManager when called locally from the public static Instance getter.
        /// </summary>
        public ApplicationManager()
        {
            this.AnimationManager = new AnimationManager(this);
            this.ActionManager = new ActionManager(this);
            this.RecentFiles = new RecentFileManager(this);
            
        }

        #region Methods

        /// <summary>
        /// Gets the ToolStripMenuItem that matches the specified name.  This searches
        /// the members recursively, so child menus should all be searched.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ToolStripMenuItem GetMenu(string name) {
            if (this.Menu != null) {
                for (int i = 0; i < Menu.Items.Count; i++)
                {
                    ToolStripMenuItem header = Menu.Items[i] as ToolStripMenuItem;
                    if (header.Name == name) {
                        return header;
                    }
                    ToolStripMenuItem result = GetMenu(header, name);
                    if (result != null) {
                        return result;
                    }
                }
            }
            return null;
        }

        private ToolStripMenuItem GetMenu(ToolStripMenuItem parent, string name) {
            foreach (ToolStripItem child in parent.DropDownItems) {
                ToolStripMenuItem childMenu = child as ToolStripMenuItem;
                if (childMenu != null) {
                    if (childMenu.Name == name)
                    {
                        return childMenu;
                    }
                }
                
            }
            return null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// This doesn't require it to be the MainForm class from this application.
        /// This can be any form that is set up to contain the project.
        /// </summary>
        public Form MainForm { get; set; }

        /// <summary>
        /// Gets or sets the AnimationManager to use with the controls on this applicationManager.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AnimationManager AnimationManager { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ActionManager ActionManager { get; set; }

        /// <summary>
        /// Gets or sets the slider for actions to work with
        /// </summary>
        public SelectableSlider Slider { get; set; }

        /// <summary>
        /// Gets or sets the viewer for actions to work with.
        /// </summary>
        public SkeletonView Viewer { get; set; }

        /// <summary>
        /// Gets or sets the main menu for the application.
        /// </summary>
        public MenuStrip Menu { get; set; }

        /// <summary>
        /// Gets or sets the play button.
        /// </summary>
        public Button ButtonPlay { get; set; }

        /// <summary>
        /// Gets or sets the record button.
        /// </summary>
        public Button ButtonRecord { get; set; }

        /// <summary>
        /// Gets or sets the RecentFileManager that can update the file menu.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecentFileManager RecentFiles { get; set; }

        /// <summary>
        /// Gets or sets the tool tip for this application.
        /// </summary>
        public ToolTip ToolTip { get; set; }

        /// <summary>
        /// Gets or sets the tool tip for this application
        /// </summary>
        public SliderContextMenu SliderContextMenu { get; set; }

        #endregion

    }
}
