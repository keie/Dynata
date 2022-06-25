using Ardalis.Specification;
using Domain.DynataSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{

    
    public class FolderSpecification:Specification<Folder>,ISingleResultSpecification
    {
   
        public FolderSpecification(bool includeSubFolders, bool  justHierarchy,int generations)
        {
            if (includeSubFolders) Query.Include(x => x.SubFolders);

            if (justHierarchy) Query.Where(x => x.isSubFolder != true);

            
            
            

        }
    }
}
