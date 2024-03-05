using IPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class TripService
    {
        public List<Trip> GetTrips()
        {
            TripRepository tr = new TripRepository();
            return tr.GetTripRepo();
        }

        public Trip GetTrip(int id)
        {
            TripRepository tr = new TripRepository();
            return tr.GetTripByIdRepo(id);
        }

        public bool DeleteTrip(int tripId)
        {
            TripRepository tr = new TripRepository();
            return tr.DeleteTripRepo(tripId);
        }


        public bool AddTrip(Trip trip)
        {
            TripRepository tr = new TripRepository();

            if (ValidateTripDates(trip.StartDate, trip.EndDate))
                return tr.AddTrip(trip);


            return false;
        }

        public bool UpdateTrip(Trip trip)
        {
            TripRepository tr = new TripRepository();

            if (ValidateTripDates(trip.StartDate, trip.EndDate))
                return tr.UpdateTripRepo(trip);

            return false;
        }

        /// <summary>
        /// Validates the start date and end date of the trip
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public bool ValidateTripDates(DateTime? StartDate, DateTime? EndDate)
        {
            return true ? StartDate <= EndDate : false;
        }
    }
}
