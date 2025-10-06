namespace DesignPatterns.Patterns.Behavioral.Observer
{
    public class Investor(string? name) : IObserver
    {
        private readonly string? _name = name;
        public string? Name { get => _name; }
        public void Update(string stockSymbol, decimal newPrice)
        {
            Console.WriteLine($"Notified {Name} of {stockSymbol}'s price change to {newPrice}");
        }
    }
}