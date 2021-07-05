using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreLineBotSDK.Filters;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Sample.Apps;

namespace NetCoreLineBotSDK.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly LineBotSampleApp _app;

        public LineController(LineBotSampleApp app)
        {
            _app = app;
        }

        [HttpPost]
        [LineVerifySignature]
        public async Task<IActionResult> Post(WebhookEvent request)
        {
            await _app.RunAsync(request.events);
            return Ok();
        }
    }
}
