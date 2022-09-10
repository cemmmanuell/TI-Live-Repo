namespace mmmSelfservice.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class PurchaseLines
    {
        public string DocumentNo { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string LineType { get; set; }

        public string UOM { get; set; }

        public DateTime ExpectedReceiptDate { get; set; }

        public string NoOfDays { get; set; }

        public decimal Ksh { get; set; }

        public decimal OtherCurrency { get; set; }

        public string ExpenseCategory { get; set; }

        public decimal TotalKsh { get; set; }

        public decimal TotalOtherCurrency { get; set; }

        public decimal NoOfPax { get; set; }

        public string DocumentType { get; set; }

        public string details { get; set; }

        public string Vendor1 { get; set; }

        public string Vendor2 { get; set; }

        public string Vendor3 { get; set; }

        public string Comments { get; set; }

        public int LineNo { get; set; }

        public string currencyCode { get; set; }

        public string currencyName { get; set; }
    }
}

