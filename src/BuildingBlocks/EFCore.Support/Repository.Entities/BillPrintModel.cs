using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class BillPrintModel
    {
        [Key]
        public int Id { get; set; }        
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string GSTN { get; set; }
        public string PAN { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string ReverseCharge { get;set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string TCSApplicable { get;set; }
        public DateTime DateOfSupply { get; set; }
        public string PlaceOfSupply { get; set; }
        public string Terms { get; set; }
        public string BillPartyName { get; set; }
        public string BillPartyAddress { get; set; }
        public string BillPartyGSTIN { get; set; }
        public string BillPartyPAN { get; set; }
        public string BillPartyState { get; set; }
        public string BillPartyCode { get; set; }
        public string ShipPartyName { get; set; }
        public string ShipPartyAddress { get; set; }
        public string ShipPartyGSTIN { get; set; }
        public string ShipPartyPAN { get; set; }
        public string ShipPartyState { get; set; }
        public string ShipPartyCode { get; set; }
        public decimal AmountBeforeTax { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal IGST { get; set; }
        public decimal TCS { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GstOnReverseCharge { get; set; }
        public string Declaration { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string SrNo { get; set; }
        public string ProductDescription { get; set; }
        public string HSNCode { get; set; }
        public string UOM { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal TotalRow { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalGridAmount { get; set; }
        public decimal TotalTaxValue { get; set; }
        public decimal FinalTotal { get;set; }
        public string CompanyId { get; set; }
        public string  BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string AmountInWords { get; set; }

    }
}
