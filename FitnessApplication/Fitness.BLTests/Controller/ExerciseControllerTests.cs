using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();

            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(50, 500));
            var start = DateTime.Now.AddMinutes(-30);
            var finish = DateTime.Now;
            
            // Act
            exerciseController.Add(activity, start, finish);

            // Assert
            Assert.AreEqual(activity, exerciseController.Activities.Last());
            Assert.AreEqual(activity.Name, exerciseController.Exercises.Last().Activity.Name);
        }
    }
}