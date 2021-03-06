using Application.Features.Folders.Commands.CreateFolderCommand;
using Application.Features.Folders.Queries.GetAllFolders;
using Application.Features.Folders.Queries.GetFoldersBy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DynataApi.Controllers
{

   
    //[Authorize(AuthenticationSchemes = "ApiKey,Bearer")]
    [Route("[controller]")]
    public class FolderController:BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllFoldersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllFoldersQuery { IncludeFiles=filter.IncludeFiles,JustHierarchy=filter.JustHierarchy}));
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CreateFolderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("familyByFolderId")]
        public async Task<IActionResult> Get([FromQuery] GetFamilyFoldersByIdParameters filter)
        {
            return Ok(await Mediator.Send(new GetFamilyFoldersByIdQuery { FolderFromId = filter.FolderFromId, FolderToId=filter.FolderToId,IncludeFiles=filter.IncludeFiles }));
        }

    }
}
