using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.DynataSystem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Folders.Commands.CreateFolderCommand
{
    public class CreateFolderCommand:IRequest<Response<int>>
    {
        public string? FolderName { get; set; }
        public int? FolderId { get; set; }

        public bool? isSubFolder { get; set; }
    }

    public class CreateFolderCommandHandler: IRequestHandler<CreateFolderCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Folder> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateFolderCommandHandler(IRepositoryAsync<Folder> repositoryAsync,IMapper mapper)
        {
            _mapper = mapper;
            _repositoryAsync= repositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateFolderCommand request,CancellationToken cancellationToken)
        {
            try
            {
                var newNode = _mapper.Map<Folder>(request);
                var data = await _repositoryAsync.AddAsync(newNode);
                return new Response<int>(data.Id);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
