using IPBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripTaskEFApp.Controllers
{
    public class TempTripController : Controller
    {
        // GET: TempTrip
        public ActionResult Index()
        {
            TripService tripService = new TripService();
            var trips = tripService.GetTrips();
            return View(trips);
        }
    }
}