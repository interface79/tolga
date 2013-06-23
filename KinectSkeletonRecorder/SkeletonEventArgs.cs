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

namespace KinnectTest
{
    public class SkeletonEventArgs : EventArgs
    {
        /// <summary>
        /// The private snapshot instance for this event.
        /// </summary>
        private SkeletonSnapshot _snapshot;

        /// <summary>
        /// Creates a new instance of the Skeleton snapshot
        /// </summary>
        /// <param name="snapshot"></param>
        public SkeletonEventArgs(SkeletonSnapshot snapshot) {
            _snapshot = snapshot;
        }

        /// <summary>
        /// The SkeletonSnapshot that contains serializable information for multiple skeletons for a single snapshot in time.
        /// </summary>
        public SkeletonSnapshot Snapshot
        {
            get
            {
                return _snapshot;
            }
            protected set {
                _snapshot = value;
            }

        }
    }
}
