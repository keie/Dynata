using Application.Features.Folders.Queries.GetAllFolders;
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
            return Ok(await Mediator.Send(new GetAllFoldersQuery { IncludeFiles=filter.IncludeFiles}));
        }
    }
}
