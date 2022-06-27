
using Application.Features.File.Commands.CreateFileCommand;
using Microsoft.AspNetCore.Mvc;
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
    }
}
