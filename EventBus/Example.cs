using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace EventBus
{
    class OrderCreatedEvent
    {
        public string Name { get; }

        public OrderCreatedEvent(string name)
        {
            this.Name = name;
        }
    }

    class Producer
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly string _name;

        public Producer(IEventAggregator eventAggregator, string name)
        {
            this._eventAggregator = eventAggregator;

            _name = name;
        }

        public void CreateOrder()
        {
            _eventAggregator.Publish(new OrderCreatedEvent(_name));
        }
    }

    class Consumer: IHandle<OrderCreatedEvent>
    {
        public List<string> OrdersRecievedFrom { get; set; }

        private readonly IEventAggregator _eventAggregator;

        public Consumer(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OrdersRecievedFrom = new List<string>();

            _eventAggregator.Subscribe(this);
        }

        public void Handle(OrderCreatedEvent message)
        {
            OrdersRecievedFrom.Add(message.Name);

            Console.WriteLine("Order was created by {0}", message.Name);
        }
    }
 
}
