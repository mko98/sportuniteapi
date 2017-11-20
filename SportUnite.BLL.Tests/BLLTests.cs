using Microsoft.EntityFrameworkCore;
using Moq;
using SportUnite.DAL;
using SportUnite.Domain.Models;
using Xunit;

namespace SportUnite.BLL.Tests
{
    public class BllTests
    {
        [Fact]
        public void CheckCorrectSportsRepositoryAddingAndSize()
        {
            //Arrange
            Sport sport = new Sport() { SportId = 0 };

            Mock<AppEventEntityDbContext> contextMock = new Mock<AppEventEntityDbContext>();
            Mock<DbSet<Sport>> dbSetMock = new Mock<DbSet<Sport>>();

            contextMock.Setup(a => a.Sport).Returns(dbSetMock.Object);

            var sportsRepository = new EFSportRepository(contextMock.Object);

            //Act
            sportsRepository.SaveSport(sport);

            //Assert
            dbSetMock.Verify(m => m.Add(sport), Times.Once);
            contextMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        //Niet mogelijk om te testen door de extension method
//        [Fact]
//        public void ExistingSportInDatabaseShouldBeEditedOnSave()
//        {
//            //Arrange
//            Sports sport = new Sports() { SportsId = 1 }; //Maak een sport aan met een id dat al zou bestaan
//
//            Mock<AppEventEntityDbContext> contextMock = new Mock<AppEventEntityDbContext>();
//            Mock<DbSet<Sports>> dbSetMock = new Mock<DbSet<Sports>>();
//
//            contextMock.Setup(a => a.Sports).Returns(dbSetMock.Object);
//            dbSetMock.Setup(a => a.First()).Returns(sport);
//
//            var sportsRepository = new EFSportRepository(contextMock.Object);
//
//            //Act
//            sportsRepository.SaveSport(sport);
//
//            //Assert
//            dbSetMock.Verify(m => m.Add(sport), Times.Never); //Private methodes zijn niet testbaar dus check of de if niet wordt uitgevoerd in plaats van checken of de else wordt uitgevoerd
//            contextMock.Verify(m => m.SaveChanges(), Times.Once);
//        }
    }
}
