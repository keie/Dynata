using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.DTOS;
using Domain.DynataSystem;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Folders.Queries.GetAllFolders
{
    public class GetAllFoldersQuery:IRequest<Response<List<FolderDto>>>
    {
        public bool IncludeFiles { get; set; }

        public class GetAllFoldersQueryHandler : IRequestHandler<GetAllFoldersQuery, Response<List<FolderDto>>>
        {
            private readonly IRepositoryAsync<Folder> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllFoldersQuery> _logger;


            public GetAllFoldersQueryHandler(IRepositoryAsync<Folder> repositoryAsync,IMapper mapper,ILogger<GetAllFoldersQuery> logger)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Response<List<FolderDto>>> Handle(GetAllFoldersQuery request,CancellationToken cancellation)
            {
                try
                {
                    var entityList = await _repositoryAsync.ListAsync(new FolderSpecification(request.IncludeFiles));
                    var dtos = _mapper.Map<List<FolderDto>>(entityList);
                    return new Response<List<FolderDto>>(dtos);

                }catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                
            }

        }

    }
}
