namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Approval
    {
        public string DocumentNo { get; set; }

        public string SenderID { get; set; }

        public string ApproverID { get; set; }

        public string Amount { get; set; }

        public string Status { get; set; }

        public string DateTimeSent { get; set; }
    }
}

