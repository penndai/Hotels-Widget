using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HotelWidgetController:Controller
    {
        private Domain.DummyPlaceRepository dbContext = new Domain.DummyPlaceRepository();

        public ActionResult Index(int id)
        {
            Domain.Place placeVM = new Domain.Place();

            if (id == 1)
            {
                ViewBag.filename = "Tokyo";
                ViewBag.cityid = 1;
                placeVM = dbContext.Get("Tokyo");
                placeVM.Hotels = placeVM.Hotels.OrderBy(x => x.Rate).Take(5).ToList();
            }
            else if (id == 2)
            {
                ViewBag.filename = "New_York_City";
                ViewBag.cityid = 2;
                placeVM = dbContext.Get("New_York_City");
                placeVM.Hotels = placeVM.Hotels.OrderBy(x => x.Rate).Take(5).ToList();
            }

            return PartialView(placeVM);
        }
    }
}