using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Models.Message.RichMenu;

namespace NetCoreLineBotSDK.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RichMenuController : ControllerBase
    {
        private readonly ILineMessageUtility _lineMessageUtility;

        public RichMenuController(ILineMessageUtility lineMessageUtility)
        {
            _lineMessageUtility = lineMessageUtility;
        }

        [HttpGet]
        public async Task<IActionResult> GetRichMenus()
        {
            var menus = await _lineMessageUtility.GetRichMenuListAsync();
            return Ok(menus);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRichMemu([FromBody] RichmenuDetail richMenu, string imageUrl)
        {
            var result = await _lineMessageUtility.CreateRichMenuWithImageAsync(richMenu, imageUrl);
            return Ok(result);
        }

        // Alias
    }
}