namespace mmmSelfservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Imprest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string Department { get; set; }

        public string No { get; set; }

        public string Document_Date { get; set; }

        public string Amount { get; set; }

        public string Status { get; set; }

        public List<imprestRinfoModel> ImprestList { get; set; }
    }
}

