using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Models.Common
{
    public class LineErrorResponse
    {
        public string message { get; set; }
        public LineErrorResponseDetail[] details { get; set; }
    }

    public class LineErrorResponseDetail
    {
        public string message { get; set; }
        public string property { get; set; }
    }

}
