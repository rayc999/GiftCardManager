//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiftCardAngular.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public int GiftCardId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime TransactionDate { get; set; }
    
        public virtual GiftCard GiftCard { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
