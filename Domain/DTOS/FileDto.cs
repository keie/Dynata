using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class FileDto:BaseEntity
    {
        public int? IdFolder { get; set; }
        public string? FileName { get; set; }
        public float Size { get; set; }
    }
}
