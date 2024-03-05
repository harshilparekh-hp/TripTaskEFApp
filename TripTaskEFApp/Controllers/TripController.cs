using AutoMapper;
using IPBLL;
using IPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripTaskEFApp.Models;

namespace TripTaskEFApp.Controllers
{
    public class TripController : Controller
    {
        
        // GET: Trip
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTrips()
        {
            TripService tripService = new TripService();
            var trips = tripService.GetTrips();

            List<TripVM> tripVMs = new List<TripVM>();
            
            
            // destination object = Mapper.Map<source class, destination class>(source object)
            tripVMs =  Mapper.Map<List<Trip>, List<TripVM>>(trips);

            return Json(tripVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTripById(int id)
        {
            TripService tripService = new TripService();
            var trip = tripService.GetTrip(id);
            return Json(trip, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddTrip(Trip trip)
        {
            TripService tripService = new TripService();
            var tripAdded = tripService.AddTrip(trip);
            return Json(tripAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTrip(Trip trip)
        {
            TripService tripService = new TripService();
            var tripUpdated = tripService.UpdateTrip(trip);
            return Json(tripUpdated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTrip(int id)
        {
            TripService tripService = new TripService();
            if(tripService.DeleteTrip(id))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}