using Xunit;
using Logic_Layer;

namespace Test_Project
{
    public class PositionTests
    {
        [Fact]
        public void AddPositionsToJourney()
        {
            //Arrange
            JourneyCollection journeyCollection = new JourneyCollection(true);
            PositionCollection positionCollection = new PositionCollection(true);
            Journey journey = new Journey() { Name = "test" };
            int journeyId;

            //Act
            journeyId = journeyCollection.Add(journey);

            positionCollection.Add(new Position() { JourneyID = journeyId, Speed = 1 });
            positionCollection.Add(new Position() { JourneyID = journeyId, Speed = 2 });
            positionCollection.Add(new Position() { JourneyID = journeyId, Speed = 3 });

            //Assert
            Assert.Equal(3, positionCollection.GetAllByJourney(journeyId).Count);
        }
    }
}
