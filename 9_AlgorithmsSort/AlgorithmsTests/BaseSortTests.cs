using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests
{
    [TestClass()]
    public class BaseSortTests
    {
        Base<int> algorithm;
        readonly Random rnd = new Random();
        List<int> golden;

        [TestInitialize]
        public void Init()
        {
            golden = new List<int>();

            for (var i = 0; i < 10000; i++)
            {
                golden.Add(rnd.Next(0, 100));
            }
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            // Arrange
            algorithm = new BubbleSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void ShakerSortTest()
        {
            // Arrange
            algorithm = new ShakerSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            // Arrange
            algorithm = new InsertionSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            // Arrange
            algorithm = new ShellSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void BinaryTreeSortTest()
        {
            // Arrange
            algorithm = new BinaryTreeSort<int>(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void HeapSortTest()
        {
            // Arrange
            algorithm = new HeapSort<int>(golden);
            //algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void SelectionSortTest()
        {
            // Arrange
            algorithm = new SelectionSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod()]
        public void GnomeSortTest()
        {
            // Arrange
            algorithm = new GnomeSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod]
        public void RadixLSDSortTest()
        {
            // Arrange
            algorithm = new RadixLSDSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod]
        public void RadixMSDSortTest()
        {
            // Arrange
            algorithm = new RadixMSDSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod]
        public void MergeSortTest()
        {
            // Arrange
            algorithm = new MergeSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }

        [TestMethod]
        public void QuickSortTest()
        {
            // Arrange
            //algorithm = new QuickSort<int>();
            algorithm.Items.AddRange(golden);

            // Act
            golden.Sort();
            algorithm.Sort();

            // Assert
            for (var i = 0; i < algorithm.Items.Count; i++)
            {
                Assert.AreEqual(golden[i], algorithm.Items[i]);
            }
        }
    }
}