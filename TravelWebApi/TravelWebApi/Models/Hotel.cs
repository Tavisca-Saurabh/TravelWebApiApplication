using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelWebApi.Models
{
    public class Hotel// : Common
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double StarRating { get; set; }
        public string Address { get; set; }

        //public int DurationOfStay { get; set; }
        //public DateTime CheckIn { get; set; }
        //public DateTime CheckOut { get; set; }
        //[Range(1, 5, ErrorMessage = "Cannot Choose more than 5 rooms per booking")]
        //public int Rooms { get; set; }
        //[Range(1, 10, ErrorMessage = "Cannot have more than 10 people in a booking")]
        //public int Passengers { get; set; }
    }
}