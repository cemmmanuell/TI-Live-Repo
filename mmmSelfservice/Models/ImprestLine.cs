namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImprestLine
    {
        public string No { get; set; }

        public string AccountNo { get; set; }

        public string AccountName { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }

        public string LineNo { get; set; }

        public decimal AmountSpent { get; set; }

        public decimal CashRefund { get; set; }

        public string ExpenseCategory { get; set; }

        public string Description { get; set; }

        public string currency { get; set; }

        public decimal unitcost { get; set; }

        public decimal quantity { get; set; }
    }
}

