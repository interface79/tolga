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
using Microsoft.Research.Kinect.Nui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace KinnectTest
{
    /// <summary>
    /// This is a user control that is designed to listen to the SkeletonKinectManager, and other SkeletonEvent providers
    /// </summary>
    public class SkeletonView : Control
    {
   

        List<Color> _colors;
        Bitmap _backBuffer;
        private bool _busy;
        private Projector _projector = new Projector();
        
        /// <summary>
        /// Creates a new instance of the skeleton view control.  This control is a Windows Forms control that will draw the skeleton
        /// </summary>
        public SkeletonView() {
            
            _colors = new List<Color>();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++) { 
                _colors.Add(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            }
            _projector = new Projector();
            
        }

        public void DrawSnapshot(SkeletonSnapshot snapshot)
        {
            if (_busy)
            {
                return;
            }
            _busy = true;
            foreach (SkeletonBody body in snapshot.SkeletonBodies)
            {
                DrawSkeletion(body);
            }
            _busy = false;
        }

        
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //This is necessary in order to prevent flickering.
        }

        /// <summary>
        /// Paint the background buffer to the control as an image.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            
            if (DesignMode)
            {
                e.Graphics.Clear(Color.White);
                return;
            }
            if (_backBuffer != null) {
                e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
            }
            
        }

        /// <summary>
        /// Draw the joints as colored circles, and use black lines to connect them.
        /// </summary>
        /// <param name="skeleton"></param>
        public void DrawSkeletion(SkeletonBody skeleton) {
            Bitmap drawBuffer = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(drawBuffer)) {
                g.FillRectangle(Brushes.White, 0, 0, Width, Height);
                if (skeleton != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        ConnectJoints(g, skeleton.Joints[i], skeleton.Joints[i+1], Color.Black);
                    }

                    for (int i = 4; i < 7; i++)
                    {
                        ConnectJoints(g, skeleton.Joints[i], skeleton.Joints[i + 1], Color.Black);
                    }

                    for (int i = 8; i < 11; i++)
                    {
                        ConnectJoints(g, skeleton.Joints[i], skeleton.Joints[i + 1], Color.Black);
                    }
                    for (int i = 12; i < 15; i++)
                    {
                        ConnectJoints(g, skeleton.Joints[i], skeleton.Joints[i + 1], Color.Black);
                    }
                    for (int i = 16; i < 19; i++)
                    {
                        ConnectJoints(g, skeleton.Joints[i], skeleton.Joints[i + 1], Color.Black);
                    }
                    ConnectJoints(g, skeleton.Joints[2], skeleton.Joints[4], Color.Black);
                    ConnectJoints(g, skeleton.Joints[2], skeleton.Joints[8], Color.Black);
                    ConnectJoints(g, skeleton.Joints[0], skeleton.Joints[12], Color.Black);
                    ConnectJoints(g, skeleton.Joints[0], skeleton.Joints[16], Color.Black);


                    for (int i = 0; i < 20; i++)
                    {
                        DrawJoint(g, skeleton.Joints[i], _colors[i]);
                    }
                }
            }
            
            Bitmap oldBuffer = _backBuffer;
            _backBuffer = drawBuffer;
            if (oldBuffer != null) {
                oldBuffer.Dispose();
            }
            Invalidate();
           
        }

        /// <summary>
        /// This method simply draws a line between two joints.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="joint1"></param>
        /// <param name="joint2"></param>
        /// <param name="color"></param>
        public void ConnectJoints(Graphics g, SkeletonJoint joint1, SkeletonJoint joint2, Color color) {
            Point point1 = _projector.ToPoint(joint1, Width, Height);
            Point point2 = _projector.ToPoint(joint2, Width, Height);
            using (Pen pen = new Pen(color, 2)) {
                g.DrawLine(pen, point1, point2);
            }
        }

        /// <summary>
        /// This method draws an elipse in the location of the joint itself.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="joint"></param>
        /// <param name="color"></param>
        public void DrawJoint(Graphics g, SkeletonJoint joint, Color color) {
            Point position = _projector.ToPoint(joint, Width, Height);
            using(Brush brush = new SolidBrush(color)){
                g.FillEllipse(brush, new Rectangle(position.X - 10, position.Y - 10, 20, 20));
            }
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        protected override void OnResize(EventArgs e)
        {
            Bitmap drawBuffer = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(drawBuffer))
            {
                g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            }
            _backBuffer = drawBuffer;
            base.OnResize(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _projector.Scale = _projector.Scale * 1.25f;
            }
            else {
                _projector.Scale = _projector.Scale * .8f;
            }
            base.OnMouseWheel(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseMove(e);
        }
        


    }
}
