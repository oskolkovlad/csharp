using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var genderName = "man";
            var birthDay = DateTime.Now.AddYears(-18);
            var weight = 40;
            var height = 167;

            var controller1 = new UserController(userName);

            // Act
            controller1.SetNewUserData(genderName, birthDay, weight, height);
            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(genderName, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDay, controller2.CurrentUser.BirthDay);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}