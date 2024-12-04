using Lab_3.Repositories;

namespace Lab_3.Tests;

public class LinkedListQueueTests
{
    private LinkedListQueue<int> _queue;

    [SetUp]
    public void Setup()
    {
        _queue = new LinkedListQueue<int>();
    }

    [Test]
    public void Enqueue_ItemAddedToQueue_CountIncreases()
    {
        _queue.Enqueue(10);
        _queue.Enqueue(20);

        Assert.That(_queue.Count, Is.EqualTo(2));
    }

    [Test]
    public void Dequeue_ItemRemovedFromQueue_ItemReturned()
    {
        _queue.Enqueue(10);
        _queue.Enqueue(20);

        var result = _queue.Dequeue();

        Assert.That(result, Is.EqualTo(10));
        Assert.That(_queue.Count, Is.EqualTo(1));
    }

    [Test]
    public void Peek_QueueNotEmpty_ReturnsFirstItem()
    {
        _queue.Enqueue(10);
        _queue.Enqueue(20);

        var result = _queue.Peek();

        Assert.That(result, Is.EqualTo(10));
        Assert.That(_queue.Count, Is.EqualTo(2));
    }

    [Test]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
    }

    [Test]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Peek());
    }
}