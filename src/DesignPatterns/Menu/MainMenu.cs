namespace DesignPatterns.Menu
{
    internal class MainMenu : IMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Design Patterns Demo ===");
            Console.WriteLine("1. Behavioral Patterns");
            Console.WriteLine("2. Creational Patterns");
            Console.WriteLine("3. Structural Patterns");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice (1-4): ");
        }

        public MenuResult HandleInput(string input)
        {
            input = input.ToUpper().Trim();
            switch (input)
            {
                case "1":
                    return MenuResult.Switch;  // Coordinator will switch to BehavioralMenu
                case "2":
                    Console.WriteLine("Creational patterns (coming soon)... Press any key.");
                    Console.ReadKey();
                    return MenuResult.Stay;
                case "3":
                    Console.WriteLine("Structural patterns (coming soon)... Press any key.");
                    Console.ReadKey();
                    return MenuResult.Stay;
                case "4":
                    return MenuResult.Exit;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    return MenuResult.Stay;
            }
        }
    }
}
