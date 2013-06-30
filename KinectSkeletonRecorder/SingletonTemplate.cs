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
 * The initial version of this file was created on $time$
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$
{
    /// <summary>
    /// This class is a singleton manager responsible for
    /// </summary>
    public class $safeitemname$
    {
        #region Singleton

        /// <summary>
        /// The single private instance of the singleton.
        /// </summary>
        private static $safeitemname$ _instance;

        /// <summary>
        /// Creates a new instance of the ActionManager when called locally from the public static Instance getter.
        /// </summary>
        private $safeitemname$()
        {
        }

        /// <summary>
        /// Gets the single static instance of the ActionManager that is used by the entire project.
        /// </summary>
        public static $safeitemname$ Instance
        {
            get
            {
                if (_instance == null) {
                    _instance = new $safeitemname$();
                }
                return _instance;
            }
        }

        #endregion
    }
}
