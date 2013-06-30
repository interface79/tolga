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
using System.Xml;
using System.Xml.Serialization;

namespace KinectSkeleton
{
    /// <summary>
    /// This class stores a list of snapshots.  Each snapshot can contain multiple skeleton bodies.  Each body will store 20 joint locations.
    /// </summary>
    public class SkeletonAnimation
    {

        private List<SkeletonSnapshot> _snapshots;

        /// <summary>
        /// For users not familiar with the kinect nodes, this will serialize the joint definitions
        /// at the beginning of evrey skeleton animation file for reference.
        /// </summary>
        public int HipCenter = 0;
        public int Spine = 1;
        public int ShoulderCenter = 2;
        public int Head = 3;
        public int ShoulderLeft = 4;
        public int ElbowLeft = 5;
        public int WristLeft = 6;
        public int HandLeft = 7;
        public int ShoulderRight = 8;
        public int ElbowRight = 9;
        public int WristRight = 10;
        public int HandRight = 11;
        public int HipLeft = 12;
        public int KneeLeft = 13;
        public int AnkleLeft = 14;
        public int FootLeft = 15;
        public int HipRight = 16;
        public int KneeRight = 17;
        public int AnkleRight = 18;
        public int FootRight = 19;


        /// <summary>
        /// Creates a new instance of the SkeletonAnimation class.
        /// </summary>
        public SkeletonAnimation() {
            Snapshots = new List<SkeletonSnapshot>();
        }

        

        /// <summary>
        /// This list of snapshots or skeletal frames will serialize in xml as an array, which means that 
        /// it simply lists the skeletonSnapshot sub-elements within the "Shapshots" element.
        /// </summary>
        [XmlArray("Snapshots")]
        [XmlArrayItem("SkeletonSnapshot")]
        public List<SkeletonSnapshot> Snapshots
        {
            get;
            set;
        }

       

        /// <summary>
        /// The filename is set by the file this is loaded from and should not be serialized into the file itself.
        /// </summary>
        [XmlIgnore]
        public string Filename { get; set; }

        /// <summary>
        /// The string name of this animation.  This is not the same as the fileaname and is simply used for a reference.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Serializes the entire animation into the specified filename.
        /// </summary>
        /// <param name="filename">The string filename to save the animation to.</param>
        public void Save(string filename) {
            XmlSerializer x = new XmlSerializer(typeof(SkeletonAnimation));
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            XmlWriter writer = XmlWriter.Create(new StreamWriter(filename), set);
            x.Serialize(writer, this);
        }

        /// <summary>
        /// Opens the entire serailized animation from the specified file into memory.
        /// </summary>
        /// <param name="filename">The string xml filename to load.</param>
        public void Open(string filename) {
            XmlSerializer x = new XmlSerializer(typeof(SkeletonAnimation));
            SkeletonAnimation hidden = (SkeletonAnimation)x.Deserialize(new FileStream(filename, FileMode.Open, FileAccess.Read));
            Name = hidden.Name;
            Snapshots = hidden.Snapshots;

        }

    }


}
