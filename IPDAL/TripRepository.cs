using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    public class TripRepository
    {
        public List<Trip> GetTripRepo()
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            return ipe.Trips.ToList();
        }

        public bool DeleteTripRepo(int tripId)
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            var trip = ipe.Trips.Where(x => x.TripId == tripId).FirstOrDefault();
            if(trip != null)
            {
                ipe.Trips.Remove(trip);
                ipe.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddTrip(Trip trip)
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            if(trip != null)
            {
                ipe.Trips.Add(trip);
                ipe.SaveChanges();
                return true;
            }
            return false;
        }


        public bool UpdateTripRepo(Trip trip)
        {
            // get the existing object from context using trip.tripid
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            Trip tripToBeUpdated = ipe.Trips.FirstOrDefault(x => x.TripId == trip.TripId);

            if(tripToBeUpdated != null)
            {
                // assign new or updated object to the existing object
                // save changes
                Mapper.Map(trip, tripToBeUpdated);
                ipe.SaveChanges();
                return true;
            }
            return false;
            
        }

        public Trip GetTripByIdRepo(int id)
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            return ipe.Trips.FirstOrDefault(x => x.TripId == id);
        }
    }
}
