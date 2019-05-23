using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PowerBI_AzureAD.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public Dictionary<string, string> Get()
        {
            return new Dictionary<string, string> {
                { "CPU", "1" },
                { "Memory", ".8" },
                { "Disk", ".45" }
            };
        }
    }
}
