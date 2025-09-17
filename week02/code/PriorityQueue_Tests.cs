using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them
    // Expected Result: Items should come out in priority order (highest priority first)
    // Defect(s) Found: Last item in queue not checked due to loop condition, items not removed from queue after dequeue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority
    // Expected Result: Items with same priority should come out in FIFO order (first added, first removed)
    // Defect(s) Found: Priority comparison uses >= instead of >, causing LIFO behavior for items with same priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Exception handling works correctly - no defects found
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                             e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Mix of priorities with some ties, added in non-priority order
    // Expected Result: Higher priorities first, FIFO within same priority groups
    // Defect(s) Found: Combination of loop condition issue and priority comparison issue causes incorrect ordering
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First priority 3
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second priority 3
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Priority 1
    }
}