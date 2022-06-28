using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Folders.Queries.GetFoldersBy
{
    public class GetFamilyFoldersByIdParameters
    {
        public int FolderFromId { get; set; }
        public int FolderToId { get; set; }
        public bool IncludeFiles { get; set; }
    }
}
