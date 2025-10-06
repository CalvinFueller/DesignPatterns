namespace DesignPatterns.Menu.Behavioral.Observer
{
    [MenuKey(MenuEnum.Behavioral)]
    public class BehavioralMenu : IMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Behavioral Patterns ===");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Observer Pattern");
            Console.WriteLine("2. Exit this Program");
            Console.WriteLine("\nEnter your choice (1 or 0): ");
        }

        public MenuResult HandleInput(string input)
        {
            input = input.ToUpper().Trim();
            switch (input)
            {
                case "0":
                    return MenuResult.Back();
                case "1":
                    // TODO: Integrate pattern runner, e.g., RunObserverDemo();
                    Console.WriteLine("Observer demo would run here... Press any key to continue.");
                    Console.ReadKey();
                    return MenuResult.Stay();
                case "2":
                    return MenuResult.Exit();
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    return MenuResult.Stay();
            }
        }
    }
}
