﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.HelperModels
{
    /// <summary>
    ///  Microservice start result class
    /// </summary>
    public class ApplicationStartResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
    }
}
