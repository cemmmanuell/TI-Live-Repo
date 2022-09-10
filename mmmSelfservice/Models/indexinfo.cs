namespace mmmSelfservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class indexinfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string Department { get; set; }

        public string AllocatedLeaveDays { get; set; }

        public string LeaveCarryForward { get; set; }

        public string TotalLeaveDays { get; set; }

        public string LeaveBalance { get; set; }

        public string TotalLeaveTaken { get; set; }

        public string NHIF { get; set; }

        public string NSSF { get; set; }

        public string Jobid { get; set; }

        public string annualLeaveAcc { get; set; }

        public string compasionateLeaveAcc { get; set; }

        public string maternityLeaveAcc { get; set; }

        public string paternityLeaveAcc { get; set; }

        public string sickLeaveAcc { get; set; }

        public string studyLeaveAcc { get; set; }

        public string Notice { get; set; }

        public string Cto { get; set; }

        public List<noticesnew> notices { get; set; }

        public string picture { get; set; }

        public string title { get; set; }

        public string name { get; set; }

        public string summary { get; set; }
    }
}

