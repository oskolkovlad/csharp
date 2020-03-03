using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();

            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food, eatingController.Foods.Last());
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.Last().Key.Name); 
        }
    }
}