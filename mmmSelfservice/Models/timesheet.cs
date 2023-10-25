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
        public DateTime endDate { get; set; }
        public string projectCode { get; set; }
        public decimal year { get; set; }
        public string status { get; set; }
       
        public List<TimesheetLinesL> Timesheetlines { get; set; }



    }
   
    public class TimesheetLinesL: timesheet
    {
        public string projectText { get; set; }
        public decimal  hours { get; set; }
        public string date { get; set; }
        public string comments { get; set; }
        public string entryno { get;set;}

    }

    
}