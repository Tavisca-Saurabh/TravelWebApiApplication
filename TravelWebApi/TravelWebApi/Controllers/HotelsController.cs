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
    [RoutePrefix("api/hotel")]
    public class HotelsController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddHotel(Hotel hotel)
        {
            var isSuccessful = HotelDAL.Add(hotel);
            if (isSuccessful)
                return Ok("Hotel Added successfully");
            return BadRequest("Could not add hotel");
        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetAllHotels()
        {
            var hotels = HotelDAL.GetAll();
            if (hotels != null)
            {
                return Ok(hotels);
            }
            return NotFound();//("No Hotel Found with the given ID");
        }

        [Route("book/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Book(Guid id)
        {
            var hotel = HotelDAL.Booking(id);
            if (hotel)
            {
                return Ok(hotel);
            }
            return BadRequest("Could not Book hotel"); ;//("No Hotel Found with the given ID");
        }
        [Route("save/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Save(Guid id)
        {
            var hotel = HotelDAL.Saving(id);
            if (hotel)
            {
                return Ok(hotel);
            }
            return BadRequest("Could not Save hotel"); ;//("No Hotel Found with the given ID");
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
