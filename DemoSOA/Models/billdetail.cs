using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoSOA.Models
{
    public class billdetail
    {
        public int id { get; set; }
        public int bill_no { get; set; }
        public string title { get; set; }
        public int date { get; set; }
        public string created_by { get; set; }
    }
}
