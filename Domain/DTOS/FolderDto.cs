using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class FolderDto:BaseEntity
    {
        public int FolderId { get; set; }
        public List<FolderDto> SubFolders { get; set; }
        public List<FileDto> Files { get; set; }
        public string? FolderName { get; set; }
        public float? Size { get; set; }
        public bool isSubFolder { get; set; }
        public string? Url { get; set; }
        public int? Level { get; set; }
    }
}
