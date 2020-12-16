using System;
using System.Collections;
using System.Collections.Generic;

/*
 * generic priority queue
 * get the order by a float parameter(priority)
 */
public class PriorityQueue<T>
{
    // The items and priorities.
    List<T> Values = new List<T>();
    List<float> Priorities = new List<float>();

    // Return the number of items in the queue.
    public int Size
    {
        get
        {
            return Values.Count;
        }
    }

    // Add an item to the queue.
    public void Enqueue(T new_value, float new_priority)
    {
        Values.Add(new_value);
        Priorities.Add(new_priority);
    }

    // Remove the item with the largest priority from the queue.
    public void Dequeue()
    {
        // Find the hightest priority.
        int best_index = 0;
        float best_priority = Priorities[0];
        for (int i = 1; i < Priorities.Count; i++)
        {
            //checks if we have a lower weight (not higher)
            if (best_priority > Priorities[i])
            {
                best_priority = Priorities[i];
                best_index = i;
            }
        }
        // Remove the item from the lists.
        Values.RemoveAt(best_index);
        Priorities.RemoveAt(best_index);
    }

    public T Peek()
    {
        // Find the hightest priority.
        int best_index = 0;
        float best_priority = Priorities[0];
        for (int i = 1; i < Priorities.Count; i++)
        {
            //checks if we have a lower weight (not higher)
            if (best_priority > Priorities[i])
            {
                best_priority = Priorities[i];
                best_index = i;
            }
        }
        //returns the T with best priority 
        return Values[best_index];
    }

    public bool Contains(T value)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if (value.Equals(Values[i]))
            {
                return true;
            }
        }
        return false;
    }

    public float getWeight(T value)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if (value.Equals(Values[i]))
            {
                return Priorities[i];
            }
        }
        return -1;
    }

    public void setWeight(T value, float new_value)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if (value.Equals(Values[i]))
            {
                Priorities[i] = new_value;
            }
        }
    }
}
