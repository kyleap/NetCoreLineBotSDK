using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILineMessageUtility lineMessageUtility;
        public LineController(ILineMessageUtility _lineMessageUtility)
        {
            lineMessageUtility = _lineMessageUtility;
        }

        [HttpPost]
        [LineVerifySignature]
        public async Task<IActionResult> Post(WebhookEvent request)
        {
            var app = new LineBotSampleApp(lineMessageUtility);
            await app.RunAsync(request.events);
            return Ok();
        }
    }
}
