using Microsoft.AspNetCore.Mvc;
using Services.Implements.Test;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        private readonly ITestService _service;

        public TestController(ITestService service) : base()
        {
            _service=service;
        }

        public IActionResult DoSomeThing()
        {
            var result = _service.DoSomeThing();
            return OptionResult(result);
        }
    }
}
