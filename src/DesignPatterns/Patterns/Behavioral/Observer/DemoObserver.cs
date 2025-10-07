namespace DesignPatterns.Patterns.Behavioral.Observer
{
    public class DemoObserver
    {
        public static void Run()
        {
            Stock stock;
            List<Investor> investors = new();

            Console.Clear();
            Console.WriteLine("=== Observer Pattern Demo ===");

            // Step 1: Create a stock and investors
            Console.WriteLine("\nStep 1: Creating instances of a stock and investors. Press any key to continue.");
            Console.ReadKey();

            stock = new Stock("AAPL", 219.90m);
            Console.WriteLine($"Created stock: {stock.Symbol} at price {stock.Price}");
            for (int i = 1; i <= 3; i++)
            {
                investors.Add(new Investor($"Investor {i}"));
                Console.WriteLine($"Created {investors.Last().Name}");
            }

            // Step 2: Subscribe to stock's observer list.
            Console.WriteLine("\nStep 2: Investors will now subscribe to the stock's observer list. Press any key to continue.");
            Console.ReadKey();

            foreach (var investor in investors)
            {
                stock.Subscribe(investor);
            }

            // Step 3: Change the price of the stock
            Console.WriteLine("\nStep 3: Now let's change the stock prize, which will trigger the Notify() method to inform\nall investors about this price change. Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("\n=== Interactive Mode - Change price ===");
            Console.WriteLine("Enter new prices (type 'X' to exit):");

            while (true)
            {
                Console.Write("\nNew price: ");
                string? input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "X")
                {
                    Console.WriteLine("Exiting interactive mode.");
                    return;
                }

                if (decimal.TryParse(input, out decimal newPrice))
                {
                    if (newPrice == stock.Price)
                    {
                        Console.WriteLine("Price unchanged. Try a different value.");
                        continue;
                    }

                    stock.Price = newPrice;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid decimal or 'X'.");
                }
            }

            // Step 4: Remove an investor
            Console.WriteLine("\nStep 4: Now let's remove an investor and see what a price change will do now. Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("\n=== Interactive Mode - Remove investor ===");
            Console.WriteLine("1 - 3. to remove Investor | X. Exit");

            while (true)
            {
                Console.Write("Choice: ");
                string? choice = Console.ReadLine()?.Trim().ToUpper();

                if (choice == "X")
                {
                    Console.WriteLine("Exiting interactive mode.");
                    break;
                }

                if (int.TryParse(choice, out int num) && (num > 0 && num < 4))
                {
                    stock.Unsubscribe(investors.ElementAt(num - 1));
                    investors.RemoveAt(num - 1);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid. Try 1, 2, 3 or X.");
                    continue;
                }
            }

            Console.WriteLine("\nMaking a price change now. Press any key to continue.\n");
            Console.ReadKey();

            stock.Price += 10;

            Console.WriteLine("\nDemo has ended. Press any key to see the recap.");
            Console.ReadKey();

            // Recap
            Console.Clear();
            Console.WriteLine("=== Observer Pattern Recap ===");
            Console.WriteLine("The Observer pattern defines a one-to-many dependency where a subject notifies multiple observers\nof state changes without tight coupling.");
            Console.WriteLine("\nKey Components & Steps:");
            Console.WriteLine("1. Define IObserver interface with Update() method (observers react here).");
            Console.WriteLine("2. Subject class:");
            Console.WriteLine("   - Holds private state (e.g., Price) and list of IObserver.");
            Console.WriteLine("   - Subscribe()/Unsubscribe() to manage observers.");
            Console.WriteLine("   - Notify() loops and calls Update() on each.");
            Console.WriteLine("   - State change (e.g., via property setter) triggers Notify().");
            Console.WriteLine("3. Concrete Observer implements IObserver.Update().");
            Console.WriteLine("4. Usage: Create subject/observers, attach, change state → auto-notify!");
            Console.WriteLine("\nDemo showed: Subscribe investors → Change price → Notify → Unsubscribe an investor →\nChange price again → Only subscribed investors notified.");
            Console.WriteLine("Benefits: Loose coupling, easy add/remove observers.");
            Console.WriteLine("\nPress any key in order to return to the previous menu.");
            Console.ReadKey();
        }
    }
}
