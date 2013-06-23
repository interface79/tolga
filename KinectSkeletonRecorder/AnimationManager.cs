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
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinnectTest
{
    public class AnimationManager
    {

        #region events

        /// <summary>
        /// Skeleton Ready.
        /// </summary>
        public event EventHandler<SkeletonEventArgs> SkeletonReady;

        /// <summary>
        /// Raises the SkeletonReady event in a way that can be overridden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnSkeletonReady(object sender, SkeletonEventArgs e) {
            if (SkeletonReady != null) {
                SkeletonReady(sender, e);
            }
        }

        /// <summary>
        /// Occurs when playback has reached the final position.
        /// </summary>
        public event EventHandler PlayEnded;

        /// <summary>
        /// Raises the PlayEnded event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPlayEnded(object sender, EventArgs e) {
            if (PlayEnded != null)
            {
                PlayEnded(sender, e);
            }
        }

        #endregion

        Timer _playTimer = new Timer();
        private int _playPosition;

        #region Singleton

        /// <summary>
        /// the private static instance that is part of the Singleton pattern.
        /// </summary>
        private static AnimationManager _instance;

        /// <summary>
        /// Gets an instance for this manager.
        /// </summary>
        public static AnimationManager Instance
        {
            get
            {
                if (_instance == null) {
                    _instance = new AnimationManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Part of the singleton pattern, this private constructor is only called by the Instance getter.
        /// </summary>
        private AnimationManager() {
            _playTimer.Interval = 30;
            _playTimer.Tick += PlayTimer_Tick;
            SkeletonKinectManager.Instance.SkeletonReady += Instance_SkeletonReady;
        }

        void Instance_SkeletonReady(object sender, SkeletonEventArgs e)
        {
            CurrentAnimation.Snapshots.Add(e.Snapshot);
        }

        #endregion




        #region Properties

        /// <summary>
        /// Gets or sets the current animation that the controls should be working with.
        /// </summary>
        public SkeletonAnimation CurrentAnimation { get; set; }


        /// <summary>
        /// When playing back an animation, this keeps track of the current frame.
        /// </summary>
        public SkeletonSnapshot CurrentSnapshot { get; set; }

        /// <summary>
        /// Gets or sets the integer value that represents the current play position for the animation.
        /// </summary>
        public int PlayPosition
        {
            get { return _playPosition; }
            set { 
                _playPosition = value;
                UpdateSnapshot();
            }
        }


        /// <summary>
        /// Gets whether or not the animation is actively playing.
        /// </summary>
        public bool Playing { get; protected set; }

        /// <summary>
        /// Gets the number of snapshot frames currently stored in the animation sequence.
        /// </summary>
        public int SnapshotCount { 
            get {
                if (CurrentAnimation != null) {
                    return CurrentAnimation.Snapshots.Count;
                }
                return 0;
            }
        }
        #endregion

        void PlayTimer_Tick(object sender, EventArgs e)
        {
            _playPosition += 1;
            UpdateSnapshot();
        }

        public void UpdateSnapshot() {
            if (_playPosition > 0 && _playPosition < SnapshotCount)
            {
                CurrentSnapshot = CurrentAnimation.Snapshots[_playPosition];
                OnSkeletonReady(this, new SkeletonEventArgs(CurrentSnapshot));

            }
            else
            {
                _playTimer.Stop();
                _playPosition = 0;
                Playing = false;
                OnPlayEnded(this, EventArgs.Empty);
            }
        }

        public void Start() {
            _playTimer.Start();
            Playing = true;
        }

        public void Stop() {
            _playTimer.Stop();
            Playing = false;
        }
    }
}
