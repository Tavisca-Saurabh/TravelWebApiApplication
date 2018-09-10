using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelWebApi.DataAccessLayer;
using TravelWebApi.Models;

namespace TravelWebApi.Controllers
{
    [RoutePrefix("api/air")]
    public class AirController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddAir(Air AirFlight)
        {
            var isSuccessful = AirDAL.Add(AirFlight);
            if (isSuccessful)
                return Ok("Hotel Added successfully");
            return BadRequest("Could not add hotel");
        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            var flights = AirDAL.GetAll();
            if (flights != null)
            {
                return Ok(flights);
            }
            return NotFound();//("No Hotel Found with the given ID");
        }

        [Route("book/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Book(Guid id)
        {
            var flights = AirDAL.Booking(id);
            if (flights)
            {
                return Ok(flights);
            }
            return BadRequest("Could not Book hotel"); ;//("No Hotel Found with the given ID");
        }
        [Route("save/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Save(Guid id)
        {
            var flights = AirDAL.Saving(id);
            if (flights)
            {
                return Ok(flights);
            }
            return BadRequest("Could not Save hotel"); ;//("No Hotel Found with the given ID");
        }
    }
}
