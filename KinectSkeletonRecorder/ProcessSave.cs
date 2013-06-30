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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectSkeleton
{
    public class ProcessSave
    {

        /// <summary>
        /// This process invokes the save method.
        /// </summary>
        /// <param name="app"></param>
        public static void Save(ApplicationManager app)
        {
            SkeletonAnimation animation = app.AnimationManager.CurrentAnimation;
            if (animation == null || animation.Snapshots.Count == 0)
            {
                MessageBox.Show(Messages.ProcessSave_NoRecording);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Messages.Animation_Files_Filter + "|*.xml";
            DialogResult r = sfd.ShowDialog(app.MainForm);
            if (r != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (string.IsNullOrEmpty(animation.Name)) {
                animation.Name = Path.GetFileNameWithoutExtension(sfd.FileName);
            }
            animation.Save(sfd.FileName);
            if (app.AnimationManager.CurrentAnimation != null)
            {
                app.MainForm.Text = app.AnimationManager.CurrentAnimation.Name;
            }
            if (app.RecentFiles != null)
            {
                app.RecentFiles.Add(sfd.FileName);
            }
        }
    }
}
