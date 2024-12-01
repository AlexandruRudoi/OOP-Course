namespace Lab_3.Domain;

public interface IQueue<T>
{
    /// <summary>
    ///     Adds an item to the end of the queue.
    /// </summary>
    /// <param name="item">The item to add to the queue.</param>
    void Enqueue(T item);

    /// <summary>
    ///     Removes and returns the item at the front of the queue.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when attempting to dequeue from an empty queue.</exception>
    T Dequeue();

    /// <summary>
    ///     Returns the item at the front of the queue without removing it.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when attempting to peek at an empty queue.</exception>
    T Peek();

    /// <summary>
    ///     Checks whether the queue is empty.
    /// </summary>
    /// <returns><c>true</c> if the queue is empty; otherwise, <c>false</c>.</returns>
    bool IsEmpty();

    /// <summary>
    ///     Gets the number of items currently in the queue.
    /// </summary>
    int Count { get; }
}