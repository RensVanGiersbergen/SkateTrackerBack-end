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
            JourneyCollection collection = new JourneyCollection(true);
            Journey journey = new Journey() { Name = "Test" };

            //Act
            var result = collection.Add(journey);

            //Assert
            Assert.Equal(1, result);
        }
    }
}