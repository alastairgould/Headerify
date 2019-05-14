using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Headerify.TestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly CaptureHeader _captureHeader;

        public TestController(CaptureHeader captureHeader) => _captureHeader = captureHeader;

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            _captureHeader.Capture(this.Request);
            return "Test Response";
        }
    }
}
