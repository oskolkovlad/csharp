using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests
{
    [TestClass()]
    public class ShakerSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            // Arrange
            var shaker = new ShakerSort<int>();
            var rnd = new Random();
            var golden = new List<int>();

            for (var i = 0; i < 1000; i++)
            {
                golden.Add(rnd.Next(0, 100));
            }
            shaker.Items.AddRange(golden);

            // Act
            golden.Sort();
            shaker.Sort();

            // Assert
            for (var i = 0; i < shaker.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], shaker.Items[i]);
            }
        }
    }
}