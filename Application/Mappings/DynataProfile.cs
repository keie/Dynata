using AutoMapper;
using Domain.DTOS;
using Domain.DynataSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DynataProfile:Profile
    {
        public DynataProfile()
        {
            CreateMap<Folder, FolderDto>();
        }
    }
}
