using Caliburn.Micro;
using NUnit.Framework;

namespace EventBus
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void EvenAggregator_GivenConsumerAndProducer_ShouldPassSubscribedEvents()
        {
            var eventAggregator = new EventAggregator();

            var producer = new Producer(eventAggregator, "Producer_A");
            var consumer = new Consumer(eventAggregator);


            producer.CreateOrder();


            Assert.That(consumer.OrdersRecievedFrom, Is.EquivalentTo(new[] { "Producer_A" }));
        }

        [Test]
        public void EvenAggregator_GivenMultipleProducers_ShouldPassSubscribedEvents()
        {
            var eventAggregator = new EventAggregator();

            var producer_A = new Producer(eventAggregator, "Producer_A");
            var producer_B = new Producer(eventAggregator, "Producer_B");
            var consumer = new Consumer(eventAggregator);


            producer_A.CreateOrder();
            producer_B.CreateOrder();


            Assert.That(consumer.OrdersRecievedFrom, Is.EquivalentTo(new[] { "Producer_A", "Producer_B" }));
        }
    }
}