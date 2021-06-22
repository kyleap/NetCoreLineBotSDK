using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using NetCoreLineBotSDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Filters
{
    public class LineVerifySignatureAttribute : TypeFilterAttribute
    {
        public LineVerifySignatureAttribute() : base(typeof(LineVerifySignatureFilter))
        {
        }
    }

    public class LineVerifySignatureFilter : IAuthorizationFilter
    {
        public IOptions<LineSetting> lineSetting { get; }

        public LineVerifySignatureFilter(IOptions<LineSetting> _lineSetting)
        {
            lineSetting = _lineSetting;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.EnableBuffering();
            string requestBody = new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync().Result;
            context.HttpContext.Request.Body.Position = 0;

            var Debug = context.HttpContext.Request.Headers["Debug"].ToString();
            var xLineSignature = context.HttpContext.Request.Headers["X-Line-Signature"].ToString();
            var channelSecret = Encoding.UTF8.GetBytes(lineSetting.Value.ChannelSecret);
            var body = Encoding.UTF8.GetBytes(requestBody);

            #if !DEBUG
            Debug = "";
            #endif
            
            if (string.IsNullOrEmpty(Debug))
            {
                using (HMACSHA256 hmac = new HMACSHA256(channelSecret))
                {
                    var hash = hmac.ComputeHash(body, 0, body.Length);
                    var xLineBytes = Convert.FromBase64String(xLineSignature);
                    if (SlowEquals(xLineBytes, hash) == false)
                    {
                        context.Result = new ForbidResult();
                    }
                }
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
