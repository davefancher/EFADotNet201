using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GuessingGame.Controllers;
using GuessingGame.Models;
using GuessingGame.Services;
using Moq;
using NUnit.Framework;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class GameControllerTests
    {
        private class MockHttpSession
            : HttpSessionStateBase
        {
            private IDictionary<string, object> _dict = new Dictionary<string, object>();

            public override object this[string name]
            {
                get { return _dict[name]; }
                set { _dict[name] = value; }
            }
        }

        private GameController CreateController()
        {
            //http://dontpaniclabs.com/blog/post/2011/03/22/testing-session-in-mvc-in-four-lines-of-code/
            var context = new Mock<ControllerContext>();
            var session = new MockHttpSession();
            context
                .Setup(m => m.HttpContext.Session)
                .Returns(session);

            var rng = new Mock<IRandomNumberGenerator>();
            rng
                .Setup(m => m.GetNext(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5);

            var controller = new GameController(rng.Object);
            controller.ControllerContext = context.Object;

            return controller;
        }

        [Test]
        public void IndexPost_DoesNotSetWinState_WhenModelStateIsInvalid()
        {
            // Arrange
            var model = new GameViewModel();
            var controller = CreateController();
            controller.ModelState.AddModelError("PlayerName", "Player name is required");

            // Act
            var result = controller.Index(model) as ViewResult;

            // Assert
            Assert.That(result.ViewBag.Win, Is.Null);
        }

        [TestCase(5, ExpectedResult = true)]
        [TestCase(9, ExpectedResult = false)]
        public bool IndexPost_SetsWinState_WhenGuessIsProvided(int guess)
        {
            // Arrange
            var model = new GameViewModel { PlayerName = "Player", Guess = guess };
            var controller = CreateController();
            controller.Index();

            // Act
            var result = controller.Index(model) as ViewResult;

            return result.ViewBag.Win;
        }
    }
}
