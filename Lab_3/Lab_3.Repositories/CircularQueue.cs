using Lab_3.Domain;

namespace Lab_3.Repositories;

public class CircularQueue<T> : IQueue<T>
{
    private readonly T[] _items;
    private int _head;
    private int _tail;
    private int _size;

    public CircularQueue(int capacity)
    {
        _items = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (_size == _items.Length)
            throw new InvalidOperationException("Queue is full");
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _size++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        T item = _items[_head];
        _head = (_head + 1) % _items.Length;
        _size--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        return _items[_head];
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public int Count => _size;
}