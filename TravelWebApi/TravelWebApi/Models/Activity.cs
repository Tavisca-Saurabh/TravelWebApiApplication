using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelWebApi.Interfaces;

namespace TravelWebApi.Models
{
    public class Activity : ITravelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Duration { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSaved { get; set; }
    }
}