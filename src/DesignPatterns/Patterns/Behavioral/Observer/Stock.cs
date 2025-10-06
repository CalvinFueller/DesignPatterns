namespace DesignPatterns.Patterns.Behavioral.Observer
{
    public class Stock(string? Symbol, decimal Price)
    {
        private readonly string? _symbol = Symbol;
        public string? Symbol { get => _symbol; }

        private decimal _price = Price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Console.WriteLine($"{_symbol} price changed to {_price}");
                    Notify();
                }
            }
        }

        private readonly List<IObserver> _observers = new();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"{(observer as Investor)?.Name} has subscribed to {_symbol} stock updates.");
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"{(observer as Investor)?.Name} has unsubscribed from {_symbol} stock updates.");
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_symbol!, _price);
            }
        }
    }
}
