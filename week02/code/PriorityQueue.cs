using System;
using System.Collections.Generic;

// Implements a priority queue where higher priority values are dequeued first.
// For items with the same priority, preserves FIFO order.
public class PriorityQueue
{
    // Internal storage: Dictionary maps priority to a queue of items.
    private SortedDictionary<int, Queue<string>> _queues = new SortedDictionary<int, Queue<string>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        if (!_queues.ContainsKey(priority))
        {
            _queues[priority] = new Queue<string>();
        }
        _queues[priority].Enqueue(value);
    }

    public string Dequeue()
    {
        foreach (var kvp in _queues)
        {
            if (kvp.Value.Count > 0)
            {
                var result = kvp.Value.Dequeue();
                // Clean up empty queues
                if (kvp.Value.Count == 0)
                    _queues.Remove(kvp.Key);
                return result;
            }
        }
        throw new InvalidOperationException("The queue is empty.");
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queues)}]";
    }
}