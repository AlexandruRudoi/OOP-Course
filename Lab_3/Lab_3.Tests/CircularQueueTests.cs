using Lab_3.Repositories;

namespace Lab_3.Tests;

public class CircularQueueTests
{
    private CircularQueue<int> _queue;

    [SetUp]
    public void Setup()
    {
        _queue = new CircularQueue<int>(3);
    }

    [Test]
    public void Enqueue_ItemAddedToQueue_CountIncreases()
    {
        _queue.Enqueue(10);
        _queue.Enqueue(20);

        Assert.That(_queue.Count, Is.EqualTo(2));
    }

    [Test]
    public void Enqueue_FullQueue_ThrowsInvalidOperationException()
    {
        _queue.Enqueue(10);
        _queue.Enqueue(20);
        _queue.Enqueue(30);

        Assert.Throws<InvalidOperationException>(() => _queue.Enqueue(40));
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