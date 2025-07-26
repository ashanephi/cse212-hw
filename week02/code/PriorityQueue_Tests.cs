using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and then dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority.
    // Defect(s) Found:
    // 1. Initial Dequeue loop condition `index < _queue.Count - 1` prevented checking the last element.
    // 2. Initial Dequeue tie-breaking `Priority >=` favored later items in case of equal priority.
    // 3. Initial Dequeue did not removes the item from the queue after returning its value.
    // All defects fixed.

    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 5);
        priorityQueue.Enqueue("Item B", 10);
        priorityQueue.Enqueue("Item C", 3);
        priorityQueue.Enqueue("Item D", 100);
        priorityQueue.Enqueue("Item E", 1);

        // Expected order: D (100), B (10), A (5), C (3), E (1)
        Assert.AreEqual("Item D", priorityQueue.Dequeue(), "Dequeue 1 failed: Should be Item D (highest priority)");
        Assert.AreEqual("Item B", priorityQueue.Dequeue(), "Dequeue 2 failed: Should be Item B");
        Assert.AreEqual("Item A", priorityQueue.Dequeue(), "Dequeue 3 failed: Should be Item A");
        Assert.AreEqual("Item C", priorityQueue.Dequeue(), "Dequeue 4 failed: Should be Item C");
        Assert.AreEqual("Item E", priorityQueue.Dequeue(), "Dequeue 5 failed: Should be Item E");
        Assert.AreEqual(0, priorityQueue.ToString().Length - 2, "Queue should be empty"); // [] means Length = 2 for "[]"
    }

    [TestMethod]
    // Scenario: Enqueue items with the same highest priority, then dequeue to check FIFO tie-breaking.
    // Expected Result: The item added first among those with the same highest priority should be dequeued first.
    // Defect(s) Found: The original Dequeue's tie-breaking logic (`>=`) picked the last encountered item with highest priority.
    // Fixed to use `>` to ensure FIFO for ties.
    public void TestPriorityQueue_DequeueTieBreakingFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 5);
        priorityQueue.Enqueue("Item B", 10); // First with priority 10
        priorityQueue.Enqueue("Item C", 5);
        priorityQueue.Enqueue("Item D", 10); // Second with priority 10
        priorityQueue.Enqueue("Item E", 2);

        // Expected order: B (10), D (10), A (5), C (5), E (2)
        Assert.AreEqual("Item B", priorityQueue.Dequeue(), "Dequeue 1 failed: Should be Item B (first with priority 10)");
        Assert.AreEqual("Item D", priorityQueue.Dequeue(), "Dequeue 2 failed: Should be Item D (second with priority 10)");
        Assert.AreEqual("Item A", priorityQueue.Dequeue(), "Dequeue 3 failed: Should be Item A (first with priority 5)");
        Assert.AreEqual("Item C", priorityQueue.Dequeue(), "Dequeue 4 failed: Should be Item C (second with priority 5)");
        Assert.AreEqual("Item E", priorityQueue.Dequeue(), "Dequeue 5 failed: Should be Item E");
        Assert.AreEqual(0, priorityQueue.ToString().Length - 2, "Queue should be empty");
    }    

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException with message "The queue is empty." should be thrown.
    // Defect(s) Found: None (The original code had this check correctly implemented).
    public void TestPriorityQueue_DequeueFromEmpty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for an empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message, "Incorrect exception message.");
        }
        catch (AssertFailedException)
        {
            throw; // Re-throw if Assert.Fail was called
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type: {e.GetType().Name}. Expected InvalidOperationException.");
        }
    }    
    [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it.
    // Expected Result: The single item should be dequeued correctly, and the queue should be empty.
    // Defect(s) Found: The original loop condition `index < _queue.Count - 1` would incorrectly handle a single item
    // if `highPriorityIndex` was not initialized to 0. Also, the item was not removed.
    // Fixed.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Single Item", 7);

        Assert.AreEqual("Single Item", priorityQueue.Dequeue(), "Dequeue failed for single item.");
        Assert.AreEqual(0, priorityQueue.ToString().Length - 2, "Queue should be empty after dequeuing single item.");

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown as queue is now empty.");
        }
        catch (InvalidOperationException)
        {
            // Expected
        }
    }

    // Add more test cases as needed below.
}