using Lab_3.Domain;

namespace Lab_3.Repositories;

public class ArrayQueue<T> : IQueue<T>
{
    private readonly List<T> _items = new List<T>();

    /// <inheritdoc />
    public void Enqueue(T item)
    {
        _items.Add(item);
    }

    /// <inheritdoc />
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        var item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    /// <inheritdoc />
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
        return _items[0];
    }

    /// <inheritdoc />
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    /// <inheritdoc />
    public int Count => _items.Count;
}