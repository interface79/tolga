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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KinectSkeleton
{
    [DefaultEvent("ValueChanged")]
    public class SelectableSlider : Control
    {
        private bool _selected;
        private Bitmap _backbuffer;
        private bool _draggingSlider;
        private bool _selecting;
        private int _selectionStartX;
        /// <summary>
        /// Occurs any time the value is actively changing by the user dragging the value.
        /// </summary>
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(object sender, EventArgs e) {
            if (ValueChanged != null) {
                ValueChanged(sender, e);
            }
        }

        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(object sender, EventArgs e) {
            if (SelectionChanged != null) {
                SelectionChanged(sender, e);
            }
        }

       

        /// <summary>
        /// Creates a new instance of the SelectableSlider class.
        /// </summary>
        public SelectableSlider() {
            Maximum = 100;
            Value = 50;
            this.Selected = true;
            SelectionStart = 25;
            SelectionEnd = 75;
            TrackColor = Color.Green;
            SliderColor = Color.Blue;
        }

        /// <summary>
        /// Gets or sets whether a region of the slider has been selected.
        /// </summary>
        [Description(" Gets or sets whether a region of the slider has been selected.")]
        [Category("Behavior")]
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value;
            DrawContent();
            }
        }

        
         private int _minimum;

        /// <summary>
        /// Gets or sets the minimum value that corresponds to the left side of the slider.
        /// </summary>
        [Description("Gets or sets the minimum value that corresponds to the left side of the slider.")]
        [Category("Behavior")]
        public int Minimum{
            get { return _minimum; }
            set { _minimum = value;
            DrawContent();
            }
        }

        private int _maximum;
       
        /// <summary>
        /// Gets or sets the maximum value that corresponds to the right side of the slider.
        /// </summary>
        [Description("Gets or sets the maximum value that corresponds to the right side of the slider.")]
        [Category("Behavior")]
        public int Maximum
        {
            get { return _maximum; }
            set { _maximum = value;
            DrawContent();
            }
        }

        private int _value;
        /// <summary>
        /// Gets or sets the value that represents the current play position of the slider.
        /// </summary>
        [Description("Gets or sets the value that represents the current play position of the slider.")]
        [Category("Behavior")]
        public int Value {
            get { return _value; }
            set {
                _value = value;
                DrawContent();
            }
        }

        private int _selectionStart;

        /// <summary>
        /// Gets or sets an integer value that represents the start of the selected region.
        /// </summary>
        [Description("Gets or sets an integer value that represents the start of the selected region.")]
        [Category("Behavior")]
        public int SelectionStart {
            get { return _selectionStart; }
            set { _selectionStart = value;
            DrawContent();
            }
        }

        private int _selectionEnd;

        /// <summary>
        /// Gets or sets an integer value that represents the end of the selected region.
        /// </summary>
        [Description("Gets or sets an integer value that represents the end of the selected region.")]
        [Category("Behavior")]
        public int SelectionEnd {
            get { return _selectionEnd; }
            set { _selectionEnd = value;
            DrawContent();
            }
        }

        private Color _trackColor;
        /// <summary>
        /// Gets or sets the color of the track line drawn down the middle of the control.
        /// </summary>
        [Description("Gets or sets the color of the track line drawn down the middle of the control.")]
        [Category("Appearance")]
        public Color TrackColor {
            get { return _trackColor; }
            set {
                _trackColor = value;
                DrawContent();
            }

        }

        private Color _selectedColor;
        /// <summary>
        /// Gets or sets the color of the selected part of the track line drawn down the middle of the control.
        /// </summary>
        [Description("Gets or sets the color of the selected part of the track line drawn down the middle of the control.")]
        [Category("Appearance")]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                DrawContent();
            }

        }

        private Color _sliderColor;
        /// <summary>
        /// Gets or sets the color of the track slider control that indicates the current play position.
        /// </summary>
        [Description("Gets or sets the color of the track line drawn down the middle of the control.")]
        [Category("Appearance")]
        public Color SliderColor {
            get { return _sliderColor; }
            set
            {
                _sliderColor = value;
                DrawContent();
            }
        }

        /// <summary>
        /// Clears the current selection so that the control will draw as if not selected.
        /// </summary>
        public void ClearSelection() {
            _selected = false;
            SelectionEnd = -1;
            SelectionStart = -1;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Prevent flicker
            //base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_backbuffer == null) {
                DrawContent();
            }
            Rectangle rect = e.ClipRectangle;
            rect.Intersect(ClientRectangle);
            e.Graphics.DrawImage(_backbuffer, rect, rect, GraphicsUnit.Pixel);
        }

        public void DrawContent()
        {
            if (Width <= 0 || Height <= 0) {
                return;
            }
            Bitmap bmp = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush b = new SolidBrush(BackColor)) {
                    g.FillRectangle(b, new Rectangle(0, 0, Width, Height));
                }
               
                DrawSelectedBackground(g);
                DrawTrackBackground(g);
                DrawTrack(g);
                DrawSelectedTrack(g);
                DrawTicks(g);
                DrawSlider(g);
                
            }
            Bitmap oldBuffer = _backbuffer;
            _backbuffer = bmp;
            if (oldBuffer != null) {
                oldBuffer.Dispose();
            }
            Invalidate();
        }

        public void DrawSelectedBackground(Graphics g) {
            if (!Enabled) {
                return;
            }
            if (!Selected) {
                return;
            }
            int start = GetX(SelectionStart);
            int end = GetX(SelectionEnd);
            using (Brush b = new SolidBrush(SelectedColor)) {
                g.FillRectangle(b, new Rectangle(start, 0, end - start, Height));
            }
        }

        public void DrawTrackBackground(Graphics g)
        {
            Color dark = Color.Gray;
            if (!Enabled) {
                dark = Color.LightGray;
            }
            using (Brush backBrush = new LinearGradientBrush(TrackBounds, dark, Color.Silver, LinearGradientMode.Vertical))
            {
                g.FillRectangle(backBrush, TrackBounds);
            }
        }

        public void DrawTrack(Graphics g) {

            if (!Enabled) {
                return;
            }

            HSLColor trackColor = new HSLColor(TrackColor);
            trackColor.Luminosity = .9;
            Color light = (Color)trackColor;
            trackColor.Luminosity = .25;
            Color dark = (Color)(trackColor);

            int playWidth = GetX(Value) - 10;
            using (Brush fillBrush = new LinearGradientBrush(TrackBounds, light, dark, LinearGradientMode.Vertical))
            {
                g.FillRectangle(fillBrush, new Rectangle(10, 15, playWidth, 5));
            }
            
            
        }

        private void DrawTicks(Graphics g) {
            Color tickColor = Color.Gray;
            if (!Enabled) {
                tickColor = Color.LightGray;
            }
            using (Pen p = new Pen(tickColor)) {
                for (int i = 0; i < 11; i++)
                {
                    int x = 10 + ((Width - 20) * i) / 10;
                    g.DrawLine(p, x, 25, x, 29);
                }
            }
           
        }

        public Rectangle TrackBounds
        {
            get
            {
                Rectangle result = new Rectangle(10, 15, Width - 20, 5);
                return result;
            }
        }

        public void DrawSelectedTrack(Graphics g)
        {
            if (!Selected)
            {
                return;
            }
            if (!Enabled) {
                return;
            }

            HSLColor trackColor = new HSLColor(SelectedColor);
            trackColor.Luminosity = .9;
            Color light = (Color)trackColor;
            trackColor.Luminosity = .25;
            Color dark = (Color)(trackColor);

            int start = GetX(SelectionStart);
            int endValue = SelectionEnd;
            if (Value < endValue) {
                endValue = Value;
            }
            int width = GetX(endValue) - start;
           
            using (Brush fillBrush = new LinearGradientBrush(TrackBounds, light, dark, LinearGradientMode.Vertical))
            {
                g.FillRectangle(fillBrush, new Rectangle(start, 15, width, 5));
            }


        }

        private int GetX(int value)
        {
            int x = 10;
            if (value > 0 && Maximum > Minimum)
            {
                x = 10 + (Width - 20) * (value - Minimum) / (Maximum - Minimum);
            }
            return x;

        }
        private int GetValue(int x) {
            if (x < 10) {
                return Minimum;
            }
            if (x > (Width - 10)) {
                return Maximum;
            }
            int value = Minimum + ((x - 10) * (Maximum - Minimum)) / (Width - 20);
            return value;
        }


        private Rectangle SliderBounds
        {
            get
            {
                int playPosition = GetX(Value);
                return new Rectangle(playPosition - 7, 7, 14, Height - 25);
            }
        }

        public void DrawSlider(Graphics g) {
            HSLColor hslSlider = new HSLColor(SliderColor);
            if (!Enabled)
            {
                hslSlider = new HSLColor(BackColor);
            }
            hslSlider.Luminosity = .9;
            Color light = (Color)(hslSlider);
            hslSlider.Luminosity = .5;
            if (!Enabled)
            {
                hslSlider.Luminosity = .8;
            }
            Color dark = (Color)(hslSlider);
            Rectangle sliderRect = SliderBounds;
            if (sliderRect.Height <= 0 || sliderRect.Width <= 0) {
                return;
            }
            using(Brush fillBrush = new LinearGradientBrush(sliderRect, light, dark, LinearGradientMode.ForwardDiagonal)){
                g.FillEllipse(fillBrush, sliderRect);
            }
            
        
        }

        protected override void OnResize(EventArgs e)
        {
            DrawContent();
           
            base.OnResize(e);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left) {
                if (SliderBounds.Contains(e.Location))
                {
                    _draggingSlider = true;
                }
                else
                {
                    _selecting = true;
                    Selected = false;
                    OnSelectionChanged(this, EventArgs.Empty);
                    _selectionStart = GetValue(e.X);
                    _selectionStartX = e.X;
                }
               
            }
            
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_draggingSlider) {
                Value = GetValue(e.X);
                OnValueChanged(this, EventArgs.Empty);
            }
            if (_selecting) {
                if (e.X < _selectionStartX)
                {
                    SelectionStart = GetValue(e.X);
                    SelectionEnd = _selectionStart;
                    Selected = true;
                    OnSelectionChanged(this, EventArgs.Empty);
                }
                else if(e.X > _selectionStartX) {
                    Selected = true;
                    SelectionStart = _selectionStart;
                    SelectionEnd = GetValue(e.X);
                    OnSelectionChanged(this, EventArgs.Empty);
                }
                // if it is exactly the same Selected is still false.
            }
            base.OnMouseMove(e);
        }
        

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_draggingSlider)
            {
                Value = GetValue(e.X);
                OnValueChanged(this, EventArgs.Empty);
            }
            if (_selecting)
            {
                if (e.X < _selectionStartX)
                {
                    SelectionStart = GetValue(e.X);
                    SelectionEnd = _selectionStart;
                }
                else if (e.X > _selectionStartX)
                {
                    SelectionStart = _selectionStart;
                    SelectionEnd = GetValue(e.X);
                    
                }
                else {
                    Selected = false;
                }
                OnSelectionChanged(this, EventArgs.Empty);
            }
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
            {
                _draggingSlider = false;
                _selecting = false;
            }
            base.OnMouseUp(e);
        }



    }
}
