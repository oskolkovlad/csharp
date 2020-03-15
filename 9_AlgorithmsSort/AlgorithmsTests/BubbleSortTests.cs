using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            // Arrange
            var bubble = new BubbleSort<int>();
            var rnd = new Random();
            var golden = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                golden.Add(rnd.Next(0, 100));
            }
            bubble.Items.AddRange(golden);

            // Act
            golden.Sort();
            bubble.Sort();

            // Assert
            for (var i = 0; i < bubble.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], bubble.Items[i]);
            }
        }
    }
}