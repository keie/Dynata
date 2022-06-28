using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.DTOS;
using Domain.DynataSystem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Folders.Queries.GetFoldersBy
{
    public class GetFamilyFoldersByIdQuery: IRequest<Response<List<FolderDto>>>
    {
        public int FolderFromId { get; set; }
        public int FolderToId { get; set; }
        public bool IncludeFiles { get; set; }

        

        public class GetFamilyFoldersByIdHandler : IRequestHandler<GetFamilyFoldersByIdQuery, Response<List<FolderDto>>>
        {
            private readonly IRepositoryAsync<Folder> _repositoryAsync;
            private readonly IRepositoryAsync<FileObj> _repositoryFileAsync;
            private readonly IMapper _mapper;
            DirectorySecurity securityRules = new DirectorySecurity();
            public List<int> IdAcummulated { get; set; }
            public int count = 0;
            string path = string.Empty;

            public GetFamilyFoldersByIdHandler(IRepositoryAsync<Folder> repositoryAsync, IMapper mapper, IRepositoryAsync<FileObj> repositoryFileAsync)
            {
                _repositoryAsync = repositoryAsync;
                _repositoryFileAsync = repositoryFileAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FolderDto>>> Handle(GetFamilyFoldersByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var entityList = await _repositoryAsync.ListAsync(new FolderSpecification(request.IncludeFiles));
                    var objFolderTo = entityList.Where(x => x.Id == request.FolderToId).FirstOrDefault();
                    var familyFrom = GetFamily(entityList, request.FolderFromId);
                    IdAcummulated = new List<int>();
                    AcummulateId(familyFrom); //ids family
                    if (IdAcummulated.Contains(request.FolderToId))
                    {
                        throw new Exception("Cannot copy this folder to subfolder of same folder");
                    }
                    UpdateAndCreateDirectories(familyFrom, objFolderTo, string.Empty);
                    var dtos = _mapper.Map<List<FolderDto>>(entityList);
                    return new Response<List<FolderDto>>(dtos);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task UpdateAndCreateDirectories(IEnumerable<Folder> entityList, Folder objFolderTo,string _path)
            {
                
                foreach (var node in entityList)
                {
                    
                    
                    Folder nodeCloned = new Folder();
                    nodeCloned.FolderName = count == 0 ? $"Copy of {node.FolderName}" : node.FolderName;
                    path = count == 0 ? $"{objFolderTo.Url}/{objFolderTo.FolderName}/{nodeCloned.FolderName}" : $"{_path}/{nodeCloned.FolderName}";
                    ValidateDirectory(path);
                    nodeCloned.Url = path;
                    nodeCloned.FolderId = objFolderTo.Id;
                    var newNode=await _repositoryAsync.AddAsync(nodeCloned);
                    if (node.Files.Count() > 0) UploadFilesFrom(node.Files,$"{node.Url}/{node.FolderName}",path,newNode.Id);
                    count++;
                    if (node.SubFolders.Count() > 0) UpdateAndCreateDirectories(node.SubFolders, newNode, path);
                }
            }

            public async Task UploadFilesFrom(List<FileObj> files,string path,string destination, int folderId)
            {
                try
                {
                    foreach (var file in files)
                    {
                        string fileToMove = $"{path}/{file.FileName}";
                        string moveTo = $"{destination}/{file.FileName}";
                        FileObj newFile = new FileObj();
                        newFile.FileName = file.FileName;
                        newFile.Size = file.Size;
                        newFile.Url = moveTo;
                        newFile.FolderId = folderId;
                        System.IO.File.Copy(fileToMove, moveTo);
                        var _newFile = await _repositoryFileAsync.AddAsync(newFile);
                    }
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
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

            public IEnumerable<Folder> GetFamily(IEnumerable<Folder> entityList,int id)
            {
                var family = IterationList(entityList).Where(x => x.Id==id);
                return family;
            }

            public IEnumerable<Folder> IterationList(IEnumerable<Folder> entityList)
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
                return entityList;
            }

            public void AcummulateId(IEnumerable<Folder> entityList)
            {
                foreach (var node in entityList)
                {
                    IdAcummulated.Add(node.Id);
                    if(node.SubFolders.Count()>0)AcummulateId(node.SubFolders);
                }
            }
        }
    }
}
