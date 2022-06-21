using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DynataApi.Controllers
{

   
    //[Authorize(AuthenticationSchemes = "ApiKey,Bearer")]
    [Route("[controller]")]
    public class FolderController:BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("It is ok");
        }
    }
}
