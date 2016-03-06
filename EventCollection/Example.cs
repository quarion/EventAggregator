using System;
using System.Collections.Generic;

namespace EventsAggregator
{
    class Producer
    {
        private string _name;

        public Producer(string name)
        {
            _name = name;
        }

        public void CreateOrder()
        {
            EventAggregator.Instance.OnOrderCreated(_name);
        }
    }

    class Consumer
    {
        public List<string> OrdersRecievedFrom { get; set; }

        public Consumer()
        {
            EventAggregator.Instance.OrderCreated += HandleOrderCreation;

            OrdersRecievedFrom = new List<string>();
        }

        private void HandleOrderCreation(object sender, object args)
        {
            OrdersRecievedFrom.Add((string)args);

            Console.WriteLine("Order was created by {0}", args);
        }
    }
}
