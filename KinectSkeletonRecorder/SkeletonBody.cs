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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectSkeleton
{
    /// <summary>
    /// This is a single skeleton collection of 20 joints.
    /// </summary>
    public class SkeletonBody
    {
        /// <summary>
        /// The empty SkeletonBody constructor.
        /// </summary>
        public SkeletonBody()
        {
            Joints = new SkeletonJoint[20];
        }

        /// <summary>
        /// Creates a new instance of the SkeletonBody directly from a SkeletonData object returned from the 
        /// Kinect tools.
        /// </summary>
        /// <param name="data">The SkeletonData object with information about joint positions for a single time frame.</param>
        public SkeletonBody(SkeletonData data){
            Joints = new SkeletonJoint[20];
            for (int i = 0; i < 20; i++) {
                SkeletonJoint joint = new SkeletonJoint();
                joint.X = data.Joints[(JointID)i].Position.X;
                joint.Y = data.Joints[(JointID)i].Position.Y;
                joint.Z = data.Joints[(JointID)i].Position.Z;
                joint.Index = i;
                Joints[i] = joint;
            }
        }
       
        /// <summary>
        /// The array of SkeletonJoint classes, which store the X,Y,Z postion of the joints.
        /// No special serialization handling is required as this will already serialize as an array.
        /// </summary>
        public SkeletonJoint[] Joints { get; set; }

    }
}
