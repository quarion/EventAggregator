using EventsAggregator;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [Test]
    public void EvenAggregator_GivenConsumerAndProducer_ShouldPassSubscribedEvents()
    {
        var producer = new Producer("Producer_A");
        var consumer = new Consumer();


        producer.CreateOrder();


        Assert.That(consumer.OrdersRecievedFrom, Is.EquivalentTo( new [] {"Producer_A"} ) );
    }

    [Test]
    public void EvenAggregator_GivenMultipleProducers_ShouldPassSubscribedEvents()
    {
        var producer_A = new Producer("Producer_A");
        var producer_B = new Producer("Producer_B");
        var consumer = new Consumer();


        producer_A.CreateOrder();
        producer_B.CreateOrder();


        Assert.That(consumer.OrdersRecievedFrom, Is.EquivalentTo( new[] { "Producer_A", "Producer_B" } ) );
    }
}