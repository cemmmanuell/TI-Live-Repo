using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;
    public class timesheet
    {
        public string code { get; set; }
        public string name { get; set; }
        public DateTime startdate { get; set; }
        public string projectCode { get; set; }
        public int year { get; set; }
        public IEnumerable<TImesheetlines> Timesheetlines { get; set; }

    }
    public class  TImesheetlines
    {
        public string timesheetcode { get; set; }

        
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public string comments { get; set; }
        public int entryno { get; set; }
    }
}