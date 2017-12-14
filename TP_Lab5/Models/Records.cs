using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Lab5.Models
{
    public class Records
    {
            public int Id { get; set; }
            public string cathegory { get; set; }
            public string model { get; set; }
            public string vin { get; set; }
            public string trname { get; set; }
            public string recedivs { get; set; }
            public List<Records> RecordsList { get; set; }

    }
}