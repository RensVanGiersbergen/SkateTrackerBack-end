using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingAPI.Controllers;
using TrackingAPI.JsonTransferObjects;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net.Http;
using Factory_Layer;
using Newtonsoft.Json;

namespace Test_Project
{
    public class EndpointTests: IClassFixture<WebApplicationFactory<TrackingAPI.Startup>>
    {
        readonly HttpClient _client;

        public EndpointTests(WebApplicationFactory<TrackingAPI.Startup> application)
        {
            //Arrange
            Factory.SetMockDAL();
            _client = application.CreateClient();
        }

        [Fact]
        public async Task GET_GetJourneyById_NotFound()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetJourneyById?ID=69");

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_GetJourneyById_Success()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetJourneyById?ID=1");
            var json = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.Equal("{\"id\":1,\"name\":\"journey1\",\"startTime\":\"0001-01-01T00:00:00\",\"maxSpeed\":0,\"totalTime\":0,\"rideTime\":0,\"pauseTime\":0,\"skaterID\":1}", json);
        }

        [Fact]
        public async Task GET_GetJourneyBySkater_NonExisting()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetJourneysBySkater?SkaterID=69");
            var json = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.Contains("[]", json);
        }

        [Fact]
        public async Task GET_GetJourneyBySkater_Success()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetJourneysBySkater?SkaterID=1");
            var json = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.NotEmpty(json);
        }

        [Fact]
        public async Task POST_AddJourney_InvalidContent()
        {
            //Arrange
            string testJson = "{\"Id\":0,\"Name\":\"test\",\"StartTime\":\"0001-01-01T00:00:00\",\"MaxSpeed\":0.0,\"TotalTime\":0,\"RideTime\":0,\"PauseTime\":0,\"SkaterID\": \"blablabla \"}";
            HttpContent content = new StringContent(testJson, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/Skate/AddJourney/", content);
            var results = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task POST_AddJourney_Success()
        {
            //Arrange
            string json = JsonConvert.SerializeObject(new JourneyDataObject() { Name = "journey2"});
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/Skate/AddJourney/", content);
            var results = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.IsType<int>(Convert.ToInt32(results));
        }

        [Fact]
        public async Task GET_GetPositionsByJourney_NotFound()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetPositionsByJourney?JourneyID=69");
            var json = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Assert.NotEmpty(json);
        }

        [Fact]
        public async Task GET_GetPositionsByJourney_Success()
        {
            //Act
            var response = await _client.GetAsync("/api/Skate/GetPositionsByJourney?JourneyID=1");
            var json = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Assert.NotEmpty(json);
        }

        [Fact]
        public async Task POST_SendPosition_BadRequest()
        {
            //Arrange
            string json = "{\"JourneyID\":\"bla\",\"Latitude\":0.0,\"Longitude\":0.0,\"Speed\":0.0,\"TimeStamp\":\"0001-01-01T00:00:00\"}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/Skate/SendPosition/", content);
            var results = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task POST_SendPosition_NotFound()
        {
            //Arrange
            string json = JsonConvert.SerializeObject(new PositionDataObject() { JourneyID = 69 });
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/Skate/SendPosition/", content);
            var results = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task POST_SendPosition_Success()
        {
            //Arrange
            string json = JsonConvert.SerializeObject(new PositionDataObject() { JourneyID = 1 });
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("/api/Skate/SendPosition/", content);
            var results = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
