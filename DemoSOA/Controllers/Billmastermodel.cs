using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoSOA.Controllers
{
    public class Billmastermodel
    {

        public class billm
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("bill_no")]
            public string BillNo { get; set; }
        }

        public class billmasters
        {
            public billm[] results;

        }
    }
}