//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public long ID { get; set; }
        public string ConsumerNo { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }
        public string CustomerName { get; set; }
        public string SubDivision { get; set; }
        public string ServiceProvider { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentDate { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public string BillDate { get; set; }
        public string BillDueDate { get; set; }
        public Nullable<decimal> CollectionAmount { get; set; }
        public Nullable<decimal> BatchAmount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string MICR { get; set; }
        public string MICRDATA { get; set; }
        public string CardTransactionNo { get; set; }
        public Nullable<long> BatchNo { get; set; }
        public string ReceiptNo { get; set; }
        public string BankCode { get; set; }
        public Nullable<int> Denom1 { get; set; }
        public Nullable<int> Denom2 { get; set; }
        public Nullable<int> Denom3 { get; set; }
        public Nullable<int> Denom4 { get; set; }
        public Nullable<int> Denom5 { get; set; }
        public Nullable<int> Denom6 { get; set; }
        public Nullable<int> Denom7 { get; set; }
        public Nullable<int> Denom8 { get; set; }
        public Nullable<int> Denom9 { get; set; }
        public Nullable<int> Denom10 { get; set; }
        public Nullable<int> Denom11 { get; set; }
        public Nullable<int> Denom12 { get; set; }
        public string AdditionalInfo1 { get; set; }
        public string AdditionalInfo2 { get; set; }
        public string AdditionalInfo3 { get; set; }
        public Nullable<bool> UpdatedToServerYN { get; set; }
        public Nullable<bool> DeclinedTransactionYN { get; set; }
        public Nullable<bool> DayEndClosedYN { get; set; }
        public Nullable<int> ReceiptPrintCount { get; set; }
        public string ErrorMessage { get; set; }
        public string MachineID { get; set; }
        public string KioskID { get; set; }
        public string BillMonth { get; set; }
        public string EncAc { get; set; }
        public string EncCa { get; set; }
        public string EncPd { get; set; }
        public string InvoiceNo { get; set; }
    }
}
