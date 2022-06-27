
using Application.Features.File.Commands.CreateFileCommand;
using Application.Features.File.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DynataApi.Controllers
{
    [Route("[controller]")]
    public class FileController:BaseApiController
    {
        [HttpPost()]
        public async Task<IActionResult> Post([FromQuery]CreateFileCommand command) 
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("byFolderId")]
        public async Task<IActionResult> Get([FromQuery] GetByIdFolderParameters filter)
        {
            return Ok(await Mediator.Send(new GetByIdFolderQuery { FolderId = filter.FolderId }));
        }

        [HttpGet("downloadFile")]
        public async Task<IActionResult> Get([FromQuery] string url)
        {
            var bytes = await System.IO.File.ReadAllBytesAsync(url);
            

            return File(bytes, "application/octet-stream", Path.GetFileName(url));
        }
    }
}
