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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Folders.Queries.GetAllFolders
{
    public class GetAllFoldersQuery:IRequest<Response<List<FolderDto>>>
    {
        public bool IncludeFiles { get; set; }
        public bool JustHierarchy { get; set; }

        

        public class GetAllFoldersQueryHandler : IRequestHandler<GetAllFoldersQuery, Response<List<FolderDto>>>
        {
            private readonly IRepositoryAsync<Folder> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllFoldersQuery> _logger;
            DirectorySecurity securityRules = new DirectorySecurity();

            public string Path = "D:/dynata";
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
                    var generations = await _repositoryAsync.CountAsync();
                    var entityList = await _repositoryAsync.ListAsync();
                    IterationList(entityList);
                    entityList = entityList.Where(x => (bool)x.isSubFolder==false).ToList();
                    IterationListAndSaveDirectories(entityList,null,Path);
                    var dtos = _mapper.Map<List<FolderDto>>(entityList);
                    return new Response<List<FolderDto>>(dtos);

                }catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                
            }

            public void IterationListAndSaveDirectories(List<Folder> entityList,Folder node,string path)
            {
                foreach (var _node in entityList)
                {
                    if (_node.Id != node?.Id)
                    {
                        _node.Url = path;
                        _repositoryAsync.UpdateAsync(_node);
                        path += $"/{_node.FolderName}";
                        ValidateDirectory(path);
                        if (_node.SubFolders.Count > 0) IterationListAndSaveDirectories(_node.SubFolders, _node,path);
                        path = path.Replace($"/{_node.FolderName}", string.Empty);
                    }
                    else
                    {
                        node.Url = path;
                        _repositoryAsync.UpdateAsync(_node);
                    }
                }
            }

            public void IterationList(List<Folder> entityList)
            {
                foreach (var node in entityList)
                {
                    List<Folder> childs = new List<Folder>();
                    
                    foreach (var child in entityList)
                    {
                        if (node.Id == child.FolderId)
                        {
                            childs.Add(child);
                            
                        }
                    }
                    node.SubFolders = childs;
                }
            }

            public void ValidateDirectory(string path)
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
               
                securityRules.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.Modify, AccessControlType.Allow));
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.SetAccessControl(securityRules);
                

            }





        }

    }
}
