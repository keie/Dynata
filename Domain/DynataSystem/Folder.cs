using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DynataSystem
{
    public class Folder:BaseEntity
    {
        public int? FolderId { get; set; }
        public List<Folder>? SubFolders { get; set; }
        public List<FileObj>? Files { get; set; }
        public string? FolderName { get; set; }
        public decimal? Size { get; set; }
        public bool? isSubFolder { get; set; }
        public string? Url { get; set; }



    }
}
