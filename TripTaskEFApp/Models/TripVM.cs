using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripTaskEFApp.Models
{
    public class TripVM
    {
        public int TripId { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
    }
}