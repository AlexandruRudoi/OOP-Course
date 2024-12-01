using Lab_3.Domain;

namespace Lab_3.Repositories;

public class LinkedListQueue<T> : IQueue<T>
{
    private class Node
    {
        public T Value { get; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node _head;
    private Node _tail;
    private int _count;

    /// <inheritdoc/>
    public void Enqueue(T item)
    {
        Node newNode = new Node(item);
        if (_tail != null)
            _tail.Next = newNode;
        _tail = newNode;
        if (_head == null)
            _head = _tail;
        _count++;
    }

    /// <inheritdoc/>
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        T value = _head.Value;
        _head = _head.Next;
        if (_head == null)
            _tail = null;
        _count--;
        return value;
    }

    /// <inheritdoc/>
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        return _head.Value;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return _head == null;
    }

    /// <inheritdoc/>
    public int Count => _count;
}