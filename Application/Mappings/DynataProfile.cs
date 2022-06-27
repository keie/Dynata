using Application.Features.File.Commands.CreateFileCommand;
using Application.Features.Folders.Commands.CreateFolderCommand;
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
            CreateMap<FileObj, FileDto>();
            CreateMap<FileDto, FileObj>();
            #region commands
            CreateMap<CreateFolderCommand, Folder>();
            CreateMap<CreateFileCommand, FileObj>();
            #endregion
        }
    }
}
