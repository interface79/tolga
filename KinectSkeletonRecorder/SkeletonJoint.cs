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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectSkeleton
{
   
    /// <summary>
    /// This class represents a single joint on the skeleton.
    /// </summary>
    public class SkeletonJoint : IVector
    {

        public static float SCALE = 300;
         


       

        #region Properties

        /// <summary>
        /// The integer joint index from 0 to 19 that identifies the joint in the body.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The floating point X position in meters.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// The floating point Y position in meters.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// The floating point x position in meters.
        /// </summary>
        public float Z { get; set; }

        #endregion

        

    }
}
