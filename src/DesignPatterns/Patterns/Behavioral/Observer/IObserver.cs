namespace DesignPatterns.Patterns.Behavioral.Observer
{
    public interface IObserver
    {
        void Update(string stockSymbol, decimal newPrice);
    }
}
