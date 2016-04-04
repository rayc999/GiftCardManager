using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GiftCardAngular.Data;
using GiftCardAngular.Data.BO;

namespace GiftCardAngular.Controllers
{
    public class GiftCardController : Controller
    {
        public JsonResult GetGiftCards()
        {
            try
            {
                var db = new GiftCardEntities();
                var giftCards = db.Set<GiftCard>().Include(g => g.Transactions).ToList();
                var model = giftCards.Select(g => new GiftCardBo()
                {
                    GiftCardId = g.GiftCardId,
                    BarCode = g.BarCode,
                    DatePurchased = g.DatePurchased,
                    Balance = g.Transactions.Sum(t => t.Amount)
                });

                return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                var err = e.Message;
                return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult GetGiftCard(int id)
        {
            return Content("Hello");

            try
            {
                var db = new GiftCardEntities();
                var giftCard = db.GiftCards.SingleOrDefault(gc => gc.GiftCardId == id);
                var model = new GiftCardBo()
                {
                    GiftCardId = giftCard.GiftCardId,
                    BarCode = giftCard.BarCode,
                    DatePurchased = giftCard.DatePurchased
                };
                return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                var err = e.Message;
                return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult GiftCardsListPartial()
        {
            return PartialView("_GiftCardList");
        }

        public ActionResult GiftCardDetailsPartial()
        {
            return PartialView("_GiftCardDetails");
        }
    }
}
