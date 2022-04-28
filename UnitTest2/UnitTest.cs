using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Templates;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Enqueue_AddedIfItemNotNull_IsAdded()
        {
            // Arrange
            int toAdd = 169;
            Queue<int> queue = new Queue<int>();

            // Act
            queue.Enqueue(toAdd);

            // Assert
            Assert.AreEqual(queue.Peek(), toAdd);
        }

        [TestMethod]
        public void Enqueue_NotAddedIfItemIsNull_Exception()
        {
            // Arrange
            int? toAdd = null;
            Queue<int?> queue = new Queue<int?>();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => queue.Enqueue(toAdd));
        }

        [TestMethod]
        public void Dequeue_RemovedIfQueueNotEmpty_IsRemoved()
        {
            // Arrange
            int toAdd = 169, toPeek;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(toAdd);

            // Act
            toPeek = queue.Dequeue();

            // Assert
            Assert.AreEqual(toAdd, toPeek);
            Assert.AreEqual(queue.Count, 0);
        }

        [TestMethod]
        public void Dequeue_NotRemovedIfQueueIsEmpty_Exception()
        {
            // Arrange
            Queue<int> queue = new Queue<int>();

            // Act
            // Assert
            Assert.ThrowsException<NullReferenceException>(() => queue.Dequeue());
        }
    }
}
