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
        [HttpPost]
        public IActionResult SendPosition([FromBody]System.Text.Json.JsonElement payload)
        { 
            LocationData data = JsonConvert.DeserializeObject<LocationData>(payload.ToString());

            using (SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi461941_skateapp;User Id=dbi461941_skateapp;Password=Venkzwegzep6"))
            {
                //Without EF
                //string query = "INSERT INTO Position (JourneyID, Latitude, Longtitude, Speed, TimeStamp) VALUES (@JourneyID, @Lat, @Long, @Speed, @DateTime)";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.Add("@JourneyID", System.Data.SqlDbType.Int).Value = data.JourneyID;
                //cmd.Parameters.Add("@Lat", System.Data.SqlDbType.Float).Value = data.Latitude;
                //cmd.Parameters.Add("@Long", System.Data.SqlDbType.Float).Value = data.Longtitude;
                //cmd.Parameters.Add("@Speed", System.Data.SqlDbType.Float).Value = data.Speed;
                //cmd.Parameters.Add("@DateTime", System.Data.SqlDbType.DateTime2).Value = DateTime.Now;

                //conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();

                //With EF
                context.Positions.Add(new Position { journey = new Journey { Id = data.JourneyID }, Latitude = data.Latitude, Longtitude = data.Longtitude, Speed = data.Speed, TimeStamp = data.TimeStamp });
                context.SaveChanges();
                return Json(payload);
            }
        }

        [Route("[action]/{name}")]
        [HttpPost]
        public IActionResult AddJourney(string name)
        {
            int ID = 0;

            //Without EF
            //using (SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi461941_skateapp;User Id=dbi461941_skateapp;Password=Venkzwegzep6"))
            //{
            //    string query = "INSERT INTO Journey (name) VALUES (@Name) SELECT SCOPE_IDENTITY()";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = name;

            //    conn.Open();
            //    ID = Convert.ToInt32(cmd.ExecuteScalar());
            //    conn.Close();
            //}

            //With EF
            var journey = new Journey() { Name = name };
            context.Journeys.Add(journey);
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
