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
 * The initial version of this file was created on 6/29/2013 6:03:56 PM
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectSkeleton
{
    /// <summary>
    /// The RecentFiles class
    /// </summary>
    public class RecentFileManager
    {
        #region Fields

        private ApplicationManager _app;

        #endregion

        #region Events

        #endregion

        #region Constructor


        /// <summary>
        /// Creates a new instance of the RecentFiles class.
        /// </summary>
        public RecentFileManager(ApplicationManager app)
        {
            _app = app;
            
        }

        /// <summary>
        /// Loads the recent files from the user's settings profile.
        /// </summary>
        public void Load() {

            string filesText = Properties.Settings.Default.RecentFiles;
            string[] files = filesText.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            Items = new List<string>(files);
            UpdateMenu();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Adds a new file to the registry
        /// </summary>
        /// <param name="file"></param>
        public void Add(string file) {
            
            // remove duplicates already in the list.
            if (Items != null) {
                for (int i = Items.Count-1; i >= 0; i--)
                {
                    if (Items[i] == file)
                    {
                        Items.RemoveAt(i);
                    }
                }
            }
            

            Items.Insert(0, file);
            UpdateMenu();
            Save();
        }

        /// <summary>
        /// Saves the top ten recent files back to the settings.
        /// </summary>
        public void Save() {
            int count = 10;
            if (Items.Count < count)
            {
                count = Items.Count;
            }
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += Items[i];
            };
            Properties.Settings.Default.RecentFiles = result;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Updates the windows forms menu.
        /// </summary>
        public void UpdateMenu() {
            int count = 10;
            if (Items.Count < count)
            {
                count = Items.Count;
            }
            if (_app.Menu != null) {
                ToolStripMenuItem menuRecent = _app.GetMenu("menuRecentFiles");
                if (menuRecent != null) {
                    menuRecent.DropDownItems.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        menuRecent.DropDownItems.Add(Items[i], null,File_Click);
                    };
                }
                
            }
            
        }

        public void File_Click(object sender, EventArgs e) { 
            ToolStripMenuItem menuRecent = sender as ToolStripMenuItem;
            if(menuRecent != null){
                string name = menuRecent.Text;
                if (File.Exists(name))
                {
                    Properties.Settings.Default.RecentFile = name;
                    Properties.Settings.Default.Save();
                    _app.ProcessRecentFile.Run(_app);
                }
                else
                {
                    DialogResult res = MessageBox.Show("This file did not exist.  Did you wish to remove it from this list?", "File not found", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes) {
                        for (int i = Items.Count - 1; i >= 0; i--) {
                            if (Items[i] == name) {
                                Items.RemoveAt(i);
                            }
                        }
                    }
                    this.Save();
                }
            }
          
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current list of recent files.
        /// </summary>
        public List<string> Items { get; set; }

        #endregion


    }
}
