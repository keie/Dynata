using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DynataSystem
{
    public class Folder
    {
        public int Id { get; set; } 
        public string? FolderName { get; set; }
        public float? Size { get; set; }
        public bool isSubFolder { get; set; }

    }
}
