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

namespace KinectSkeleton
{
    /// <summary>
    /// This is a user control that is designed to listen to the SkeletonKinectManager, and other SkeletonEvent providers
    /// </summary>
    public class SkeletonView : Control
    {

        #region Fields

        List<Color> _colors;
        Bitmap _backBuffer;
        private bool _busy;
        private Projector _projector = new Projector();
        private SkeletonSnapshot _currentSnapshot;

        #endregion

        #region Constructor

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

        #endregion

        #region Methods

        /// <summary>
        /// Refreshes the buffer by re-drawing the current snapshot onto the buffer image, using the current control's dimension
        /// and the current projector settings.
        /// </summary>
        public void DrawContent()
        {
            _busy = true;
            Bitmap drawBuffer = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(drawBuffer))
            {
                using (Brush b = new SolidBrush(BackColor))
                {
                    g.FillRectangle(b, new Rectangle(0, 0, Width, Height));
                }
                if (_currentSnapshot != null)
                {
                    OnDrawSnapshot(g, _currentSnapshot);
                }

            }

            Bitmap oldBuffer = _backBuffer;
            _backBuffer = drawBuffer;
            if (oldBuffer != null)
            {
                oldBuffer.Dispose();
            }

            _busy = false;
            Invalidate();


        }

        /// <summary>
        /// Updates the current snapshot and forces that snapshot to be drawn to the view.
        /// </summary>
        /// <param name="snapshot"></param>
        public void DrawSnapshot(SkeletonSnapshot snapshot) {
            _currentSnapshot = snapshot;
            DrawContent();
        }



        /// <summary>
        /// The internal call that assumes a graphics object has been dimensioned.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="snapshot"></param>
        protected virtual void OnDrawSnapshot(Graphics g, SkeletonSnapshot snapshot)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (SkeletonBody body in snapshot.SkeletonBodies)
            {
                OnDrawSkeletion(g, body);
            }
        }



        /// <summary>
        /// Prevent flicker.
        /// </summary>
        /// <param name="pevent"></param>
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
        /// <param name="skeleton">The skeleton to draw</param>
        protected virtual void OnDrawSkeletion(Graphics g, SkeletonBody skeleton) {
           
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

        /// <summary>
        /// Initialize the component 
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Force the control to redraw content to a new buffer if we resize the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            DrawContent();
            
            base.OnResize(e);
        }


        /// <summary>
        /// Changing the mouse wheel alters the scale so you can "zoom in" and "zoom out" of the view.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _projector.Scale = _projector.Scale * 1.25f;
            }
            else {
                _projector.Scale = _projector.Scale * .8f;
            }
            DrawContent();
            base.OnMouseWheel(e);
        }


        /// <summary>
        /// When the mouse moves over the control, the control gets focus so that you can zoom in and zoom out using the scroll wheel.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseMove(e);
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the optional application manager for this viewer control.  If this is set, then
        /// it enables this tool access to the application for coordinating "linked" actions. 
        /// </summary>
        [Description(" Gets or sets the optional application manager for this viewer control.  If this is set, then "+
            "it enables this tool access to the application for coordinating linked behavior"),
        Category("Behavior")]
        public ApplicationManager App { get; set; }

        #endregion

    }
}
