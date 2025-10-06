using DesignPatterns.Patterns.Behavioral.Observer;

namespace DesignPatterns.Menu.Behavioral.Observer
{
    [MenuKey(MenuEnum.Behavioral)]
    public class BehavioralMenu : IMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Behavioral Patterns ===");
            Console.WriteLine("X. Exit this Program");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Observer Pattern");
            Console.WriteLine("\nEnter your choice: ");
        }

        public MenuResult HandleInput(string input)
        {
            input = input.ToUpper().Trim();
            switch (input)
            {
                case "X":
                    return MenuResult.Exit();
                case "0":
                    return MenuResult.Back();
                case "1":
                    DemoObserver.Run();
                    return MenuResult.Stay();
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    return MenuResult.Stay();
            }
        }
    }
}
