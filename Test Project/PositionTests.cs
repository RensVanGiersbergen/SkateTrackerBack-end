using Xunit;
using Logic_Layer;
using System.Collections.Generic;

namespace Test_Project
{
    public class PositionTests
    {
        [Fact]
        public void AddPositionsToJourney()
        {
            //Arrange
            JourneyCollection journeyCollection = new JourneyCollection("AddPositionsToJourney");
            PositionCollection positionCollection = new PositionCollection("AddPositionsToJourney");
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

        [Fact]
        public void GetAllPositionsByJourney()
        {
            //Arrange
            JourneyCollection journeyCollection = new JourneyCollection("GetAllPositionsByJourney");
            PositionCollection positionCollection = new PositionCollection("GetAllPositionsByJourney");
            Journey journey = new Journey() { Name = "test" };
            int journeyId;
            List<Position> positions = new List<Position>();
            positions.Add(new Position());
            positions.Add(new Position());
            positions.Add(new Position());
            positions.Add(new Position());
            positions.Add(new Position());

            //Act
            journeyId = journeyCollection.Add(journey);

            foreach(Position position in positions)
            {
                position.JourneyID = journeyId;
                positionCollection.Add(position);
            }

            //ToDo fix assert
            //Assert
            Assert.Equal(positions, positionCollection.GetAllByJourney(journeyId));
        }
    }
}
