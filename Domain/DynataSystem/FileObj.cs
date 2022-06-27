using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DynataSystem
{
    public class FileObj:BaseEntity
    {
        public int? FolderId { get; set; }
        public string? FileName { get; set; }
        public decimal? Size { get; set; }
        public string? Url { get; set; }
        
    }
}
