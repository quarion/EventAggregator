class EventAggregator
{
    #region Singleton

    private static EventAggregator _instance;

    private EventAggregator(){
    }

    public static EventAggregator Instance => _instance ?? (_instance = new EventAggregator());

    #endregion

    // Events definitions
    internal delegate void OrderFinalizedEvent(object sender, object args);
    internal delegate void OrderCreatedEvent(object sender, object args);

    // Public accesors for events Subscribers
    public event OrderCreatedEvent OrderCreated;
    public event OrderFinalizedEvent OrderFinalized;

    // Public methods for events Publishers
    public void OnOrderFinalized(object args)
    {
        OrderFinalized?.Invoke(this, args);
    }

    public  void OnOrderCreated(object args)
    {
        OrderCreated?.Invoke(this, args);
    }
}