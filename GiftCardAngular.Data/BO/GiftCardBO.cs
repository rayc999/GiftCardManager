using System;

namespace GiftCardAngular.Data.BO
{
    public class GiftCardBo
    {
        public int GiftCardId { get; set; }
        public string BarCode { get; set; }
        public DateTime DatePurchased { get; set; }
        public decimal Balance { get; set; }
    }
}
