namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class jnllines
    {
        public string description { get; set; }

        public decimal amount { get; set; }

        public string lineno { get; set; }

        public DateTime postingdate { get; set; }

        public string documentNo { get; set; }
        public string fundCode { get; set; }

        public string glAccount { get; set; }
        public string document { get; set; }

        public string currency { get; set; }
        public string bank { get; set; }
       
    }
}

