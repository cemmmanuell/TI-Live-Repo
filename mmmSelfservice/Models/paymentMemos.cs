namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class paymentMemos
    {
        public int Id { get; set; }

        public string empno { get; set; }

        public string subject { get; set; }

        public string description { get; set; }

        public string Group { get; set; }

        public int Percentage { get; set; }
    }
}

