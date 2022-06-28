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
   
        public FolderSpecification(bool includeFiles)
        {
            if (includeFiles) Query.Include(x => x.Files);

        }
    }
}
