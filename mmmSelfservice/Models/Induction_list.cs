namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Induction_list
    {
        public string employee_no { get; set; }

        public string employee_name { get; set; }

        public string comments { get; set; }

        public bool? inducted { get; set; }

        public string inducting_employee { get; set; }

        public DateTime? date_inducted { get; set; }
    }
}

