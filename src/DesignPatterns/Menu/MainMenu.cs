namespace DesignPatterns.Menu
{
    [MenuKey(MenuEnum.Main)]
    public class MainMenu : IMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Design Patterns Demo ===");
            Console.WriteLine("X. Exit this Program");
            Console.WriteLine("1. Behavioral Patterns");
            Console.WriteLine("2. Creational Patterns");
            Console.WriteLine("3. Structural Patterns");
            Console.WriteLine("\nEnter your choice: ");
        }

        public MenuResult HandleInput(string input)
        {
            input = input.ToUpper().Trim();
            switch (input)
            {
                case "X":
                    return MenuResult.Exit();
                case "1":
                    return MenuResult.SwitchTo(MenuEnum.Behavioral);
                case "2":
                    //return MenuResult.SwitchTo(MenuEnum.Creational);
                    Console.WriteLine("Creational menu not implemented yet. Press any key to continue.");
                    Console.ReadKey();
                    return MenuResult.Stay();
                case "3":
                    //return MenuResult.SwitchTo(MenuEnum.Structural);
                    Console.WriteLine("Structural menu not implemented yet. Press any key to continue.");
                    Console.ReadKey();
                    return MenuResult.Stay();
                default:
                    Console.WriteLine("Invalid choice. Press any key.");
                    Console.ReadKey();
                    return MenuResult.Stay();
            }
        }
    }
}