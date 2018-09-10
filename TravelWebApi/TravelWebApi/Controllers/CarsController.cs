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
    [RoutePrefix("api/car")]
    public class CarsController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddAir(Car Car)
        {
            var isSuccessful = CarDAL.Add(Car);
            if (isSuccessful)
                return Ok("Hotel Added successfully");
            return BadRequest("Could not add hotel");
        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetAllCars()
        {
            var Cars = CarDAL.GetAll();
            if (Cars != null)
            {
                return Ok(Cars);
            }
            return NotFound();//("No Hotel Found with the given ID");
        }

        [Route("book/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Book(Guid id)
        {
            var Cars = CarDAL.Booking(id);
            if (Cars)
            {
                return Ok(Cars);
            }
            return BadRequest("Could not Book Car");//("No Hotel Found with the given ID");
        }
        [Route("save/{id:guid}")]
        [HttpPut]
        public IHttpActionResult Save(Guid id)
        {
            var Cars = CarDAL.Saving(id);
            if (Cars)
            {
                return Ok(Cars);
            }
            return BadRequest("Could not Save Car");//("No Hotel Found with the given ID");
        }
}
}
