using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.API.Controllers
{

    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            return Problem(statusCode:400, title:exception?.Message);
        }
    }
}
