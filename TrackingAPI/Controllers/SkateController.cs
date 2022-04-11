using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Data_Access.data;
using Data_Access.models;

namespace MQTT_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkateController : Controller
    {
        SkateTrackerContext context;

        public SkateController(SkateTrackerContext context)
        {
            this.context = context;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Test()
        {
            return Json("ok");
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult SendPosition([FromBody] System.Text.Json.JsonElement payload)
        {
            LocationData data = JsonConvert.DeserializeObject<LocationData>(payload.ToString());

            context.Position.Add(new Position { JourneyID = data.JourneyID, Latitude = data.Latitude, Longtitude = data.Longtitude, Speed = data.Speed, TimeStamp = data.TimeStamp });
            context.SaveChanges();
            return Json(payload);
        }

        [Route("[action]/{name}")]
        [HttpPost]
        public IActionResult AddJourney(string name)
        {
            var journey = new Journey() { Name = name };
            context.Journey.Add(journey);
            context.SaveChanges();

            return Ok(journey.Id);
        }
    }

    class LocationData
    {
        public int JourneyID { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public float Speed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
