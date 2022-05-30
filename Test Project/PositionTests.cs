using Xunit;
using Logic_Layer;
using System.Collections.Generic;
using System;

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
        public void AddPositionsToNonExistingJourney()
        {
            //Arrange
            PositionCollection positionCollection = new PositionCollection("AddPositionsToNonExistingJourney");
            
            //Assert
            Assert.Throws<NullReferenceException>(() => positionCollection.Add(new Position() { JourneyID = 69 }));
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

            //Assert
            Assert.Equal(positions[0].Speed, positionCollection.GetAllByJourney(journeyId)[0].Speed);
            Assert.Equal(positions[1].Speed, positionCollection.GetAllByJourney(journeyId)[1].Speed);
            Assert.Equal(positions[2].Speed, positionCollection.GetAllByJourney(journeyId)[2].Speed);
            Assert.Equal(positions[3].Speed, positionCollection.GetAllByJourney(journeyId)[3].Speed);
        }

        [Fact]
        public void GetAllPositionsFromNonExistingJourney()
        {
            //Arrange
            PositionCollection positionCollection = new PositionCollection("GetAllPositionsFromNonExistingJourney");

            //Assert
            Assert.Throws<NullReferenceException>(() => positionCollection.GetAllByJourney(69));
        }
    }
}
