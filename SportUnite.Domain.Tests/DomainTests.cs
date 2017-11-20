using SportUnite.Domain.Models;
using Xunit;

namespace SportUnite.Domain.Tests
{
    public class DomainTests
    {
        [Fact]
        public void CheckCorrectDomainClassInstantiationAndAlteration()
        {
            //Arrange
            Sport emptySport = new Sport(), football = new Sport() { SportId = 1, Name = "Voetbal", Description = "Balspel" };

            //Act
            emptySport.SportId = 2;
            emptySport.Name = "Waterpolo";
            emptySport.Description = "Watersport";

            //Assert
            Assert.Equal(1, football.SportId);
            Assert.Equal("Voetbal", football.Name);
            Assert.Equal("Balspel", football.Description);

            Assert.Equal(2, emptySport.SportId);
            Assert.Equal("Waterpolo", emptySport.Name);
            Assert.Equal("Watersport", emptySport.Description);
        }
    }
}
