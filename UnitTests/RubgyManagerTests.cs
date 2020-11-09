using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RugbyTeamManager.Controllers;
using RugbyTeamManager.Database.DBContext;
using RugbyTeamManager.Models.DTO;
using RugbyTeamManager.Models.Player;

namespace UnitTests
{
    [TestClass]
    public class RubgyManagerTests
    {
        [TestMethod]
        public void GetPlayerTest()
        {
            //var mockContext = new Mock<TeamManagerContext>();

            //// Arrange
            //var model = new CreatePlayerRequest { Player = new PlayerDTO { FirstName = null } }; // Invalid model

            //var controller = new PlayerController(null, mockContext.Object);

            //// Act
            //var result = controller.GetPlayer(0);

            //Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void CreatePlayerTest()
        {
            //var mockContext = new Mock<TeamManagerContext>();

            //// Arrange
            //var model = new CreatePlayerRequest { Player = new PlayerDTO { FirstName = null } }; // Invalid model

            //var controller = new PlayerController(null, mockContext.Object);
            //controller.ModelState.AddModelError("FirstName", "Required");

            //// Act
            //var result = controller.CreatePlayer(model);

            //Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }
    }
}
