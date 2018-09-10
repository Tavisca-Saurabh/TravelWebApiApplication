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
    [RoutePrefix("api/activity")]
    public class ActivityController : ApiController
    {
            [Route("add")]
            [HttpPost]
            public IHttpActionResult AddActivity(Activity ActivityProduct)
            {
                var isSuccessful = ActivityDAL.Add(ActivityProduct);
                if (isSuccessful)
                    return Ok("Activity Added successfully");
                return BadRequest("Could not add Activity");
            }

            [Route("get")]
            [HttpGet]
            public IHttpActionResult GetAllActivity()
            {
                var Activities = ActivityDAL.GetAll();
                if (Activities != null)
                {
                    return Ok(Activities);
                }
                return NotFound();//("No Hotel Found with the given ID");
            }

            [Route("book/{id:guid}")]
            [HttpPut]
            public IHttpActionResult Book(Guid id)
            {
                var Activities = ActivityDAL.Booking(id);
                if (Activities)
                {
                    return Ok(Activities);
                }
                return BadRequest("Could not Book Activity"); ;//("No Hotel Found with the given ID");
            }
            [Route("save/{id:guid}")]
            [HttpPut]
            public IHttpActionResult Save(Guid id)
            {
                var Activities = ActivityDAL.Saving(id);
                if (Activities)
                {
                    return Ok(Activities);
                }
                return BadRequest("Could not Save Activity"); ;//("No Hotel Found with the given ID");
            }
        }
    }

