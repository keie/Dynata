﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DynataSystem
{
    public class FileObj
    {
        public int Id { get; set; }
        public int? IdFolder { get; set; }
        public string? FileName { get; set; }
        public float Size { get; set; }
    }
}