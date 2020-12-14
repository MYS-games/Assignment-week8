using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private class PriorityQueueItem : IComparable<PriorityQueueItem>
    {
        private T item;
        private int priority;

        public PriorityQueueItem(T item, int priority)
        {
            this.item = item;
            this.priority = priority;
        }

        public T Item { get; internal set; }

        public int CompareTo(PriorityQueueItem other)
        {
            return priority.CompareTo(other.priority);
        }

        // obvious constructor, CompareTo implementation and Item accessor
    }

    // the existing PQ implementation where the item *does* need to be IComparable
    private readonly PriorityQueue<PriorityQueueItem> _inner = new PriorityQueue<PriorityQueueItem>();

    public void Enqueue(T item, int priority)
    {
        _inner.Enqueue(new PriorityQueueItem(item, priority));
    }

    public T Dequeue()
    {
        return _inner.Dequeue().Item;
    }
}
