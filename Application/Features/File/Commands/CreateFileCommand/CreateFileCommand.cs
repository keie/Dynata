using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.DTOS;
using Domain.DynataSystem;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.File.Commands.CreateFileCommand
{
    public class CreateFileCommand:IRequest<Response<int>>
    {
        public string? FileName { get; set; }
        public int? FolderId { get; set; }
        public IFormFile? File { get; set; }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Response<int>>
    {
        private readonly IRepositoryAsync<FileObj> _repositoryAsync;
        private readonly IRepositoryAsync<Folder> _repositoryFolderAsync;
        private readonly IMapper _mapper;
        public string Path = "D:/dynata";

        public CreateFileCommandHandler(IRepositoryAsync<FileObj> repositoryAsync, IRepositoryAsync<Folder> repositoryFolderAsync, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
            _repositoryFolderAsync = repositoryFolderAsync;
        }

        public async Task<Response<int>> Handle(CreateFileCommand request,CancellationToken cancellationToken)
        {
            try
            {
                FileDto dto = new FileDto();
                request.FileName = request.File.FileName;
                var folder= await _repositoryFolderAsync.GetByIdAsync(request.FolderId);
                var path =$"{folder.Url}/{folder.FolderName}";
                dto.Url=UploadFile(request,path);
                dto.FileName = request.FileName;
                dto.FolderId = request.FolderId;
                dto.Size = request.File.Length;
                var newNode=_mapper.Map<FileObj>(dto);
                var data=await _repositoryAsync.AddAsync(newNode);
                return new Response<int>(data.Id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UploadFile(CreateFileCommand request,string path)
        {
            request.File.CopyTo(new FileStream($"{path}/{request.FileName}", FileMode.Create));
            return $"{path}/{request.FileName}";
        }
    }
}
