﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public T Return { get; set; }
        public string Message { get; set; }
    }
}
