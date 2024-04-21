using Microsoft.AspNetCore.Mvc;
using Optional;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController() { }

        [NonAction]
        public IActionResult OptionResult<T>(Option<T, string> option)
        {
            return option
                    .Match<IActionResult>(success =>
                        success?.GetType() == typeof(bool) ?
                            Ok() : Ok(success), error => BadRequest(error));
        }
    }
}
