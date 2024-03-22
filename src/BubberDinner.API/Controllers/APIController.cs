using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.API.Controllers
{

    [ApiController]
    public class APIController : ControllerBase
    {
        public IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items["Errors"] = errors;
            return Problem();
        }
    }
}
