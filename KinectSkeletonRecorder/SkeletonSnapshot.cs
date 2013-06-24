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
using System.Xml.Serialization;

namespace KinectSkeleton
{
    /// <summary>
    /// Since more than one skeleton can appear in a frame, this gets the distinct, non-null skeletons observed.
    /// </summary>
    public class SkeletonSnapshot
    {
        /// <summary>
        /// Creates a new instance of the SkeletonSnapshot, which contains multiple skeleton bodies.
        /// </summary>
        public SkeletonSnapshot() {
            SkeletonBodies = new List<SkeletonBody>();
        }

        /// <summary>
        /// Creates a new isntance of the SkeletonSnapshot from an enumerable of SkeletonData.  
        /// </summary>
        /// <param name="skeletons">The skeletons to add to this snapshot.</param>
        public SkeletonSnapshot(IEnumerable<SkeletonData> skeletons)
        {
            SkeletonBodies = new List<SkeletonBody>();
            foreach (SkeletonData data in skeletons)
            {
                SkeletonBodies.Add(new SkeletonBody(data));
            }
        }

        /// <summary>
        /// This list of SkeletonBody bojects will serialize as an array, so each skeleton becomes a child entity.
        /// </summary>
        [XmlArray("SkeletonBodies")]
        [XmlArrayItem("SkeletonBody")]
        public List<SkeletonBody> SkeletonBodies { get; set; }

    }
}
