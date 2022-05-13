using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using TrackingAPI.JsonTransferObjects;
using Logic_Layer;


namespace TrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkateController : Controller
    {
        PositionCollection positionCollection = new PositionCollection();
        JourneyCollection journeyCollection = new JourneyCollection();

        [Route("[action]")]
        [HttpPost]
        public IActionResult SendPosition([FromBody] System.Text.Json.JsonElement payload)
        {
            PositionDataObject jObject = JsonConvert.DeserializeObject<PositionDataObject>(payload.ToString());
            positionCollection.Add((Position)jObject);
            
            return Json(payload);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddJourney([FromBody] System.Text.Json.JsonElement payload)
        {
            JourneyDataObject jObject = JsonConvert.DeserializeObject<JourneyDataObject>(payload.ToString());

            return Ok(journeyCollection.Add((Journey)jObject));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetJourneysBySkater(int SkaterID)

        {
            return Ok(journeyCollection.GetAllBySkater(SkaterID));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetPositionsByJourney(int JourneyID)
        {
            return Ok(positionCollection.GetAllByJourney(JourneyID));
        }

    }
}
