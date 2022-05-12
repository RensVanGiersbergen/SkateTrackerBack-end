using Xunit;
using Logic_Layer;

namespace Test_Project
{
    public class JourneyTests
    {
        [Fact]
        public void AddJourneyAndReturnID()
        {
            //Arrange
            JourneyCollection collection = new JourneyCollection("AddJourneyAndReturnID");
            Journey journey = new Journey() { Name = "Test" };

            //Act
            var result = collection.Add(journey);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetAllJourneysBySkater()
        {
            //Arrange
            JourneyCollection journeyCollection = new JourneyCollection("GetAllJourneysBySkater");
            Journey journey1 = new Journey() { Name = "Test1", SkaterID = 1 };
            Journey journey2 = new Journey() { Name = "Test2", SkaterID = 1 };

            //Act
            journeyCollection.Add(journey1);
            journeyCollection.Add(journey2);

            //Assert
            Assert.Equal(2, journeyCollection.GetAllBySkater(1).Count);
        }

        [Fact]
        public void GetNoJourneysBySkater()
        {
            //Arrange
            JourneyCollection journeyCollection = new JourneyCollection("GetNoJourneysBySkater");
            Journey journey1 = new Journey() { Name = "Test1", SkaterID = 1 };
            Journey journey2 = new Journey() { Name = "Test2", SkaterID = 2 };
            Journey journey3 = new Journey() { Name = "Test3", SkaterID = 3 };

            //Act
            journeyCollection.Add(journey1);
            journeyCollection.Add(journey2);
            journeyCollection.Add(journey3);

            //Assert
            Assert.Empty(journeyCollection.GetAllBySkater(4));
        }
    }
}