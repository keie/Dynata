using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.DTOS;
using Domain.DynataSystem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.File.Queries.GetById
{
    public class GetByIdFolderQuery:IRequest<Response<List<FileDto>>>
    {
        public int FolderId { get; set; }

        public class GetByIdFolderQueryHandler:IRequestHandler<GetByIdFolderQuery, Response<List<FileDto>>>
        {
            private readonly IRepositoryAsync<FileObj> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetByIdFolderQueryHandler(IRepositoryAsync<FileObj> repositoryAsync,IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FileDto>>> Handle(GetByIdFolderQuery resuqest,CancellationToken cancellationToken)
            {
                try
                {
                    var entityList = await _repositoryAsync.ListAsync();
                    entityList=entityList.Where(x => x.FolderId == resuqest.FolderId).ToList();
                    var dtos = _mapper.Map<List<FileDto>>(entityList);
                    return new Response<List<FileDto>>(dtos);
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
