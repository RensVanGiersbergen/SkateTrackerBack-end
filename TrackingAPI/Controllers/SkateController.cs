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
using TrackingAPI.JsonTransferObjects;

namespace TrackingAPI.Controllers
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
            PositionDataObject jObject = JsonConvert.DeserializeObject<PositionDataObject>(payload.ToString());

            context.Position.Add((Position)jObject);
            context.SaveChanges();
            return Json(payload);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddJourney([FromBody] System.Text.Json.JsonElement payload)
        {
            JourneyDataObject jObject = JsonConvert.DeserializeObject<JourneyDataObject>(payload.ToString());

            Journey journey = (Journey)jObject;
            context.Journey.Add(journey);
            context.SaveChanges();

            return Ok(journey.Id);
        }
    }
}
