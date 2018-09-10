using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelWebApi.Interfaces;

namespace TravelWebApi.Models
{
    public class Car: ITravelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }
    }
}