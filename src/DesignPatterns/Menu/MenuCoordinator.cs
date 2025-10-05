using DesignPatterns.Menu.Behavioral.Observer;

namespace DesignPatterns.Menu
{
    internal class MenuCoordinator
    {
        private readonly Stack<IMenu> _menuStack = new();
        private readonly Dictionary<string, IMenu> _availableMenus = new Dictionary<string, IMenu>();

        public MenuCoordinator()
        {
            // Register all menus here (easy to add new ones)
            _availableMenus["main"] = new MainMenu();
            _availableMenus["behavioral"] = new BehavioralMenu();
            // Add more: _availableMenus["creational"] = new CreationalMenu();
        }

        public void Run()
        {
            PushMenu("main");  // Start with main menu

            while (_menuStack.Count > 0)
            {
                var currentMenu = _menuStack.Peek();
                currentMenu.Show();

                string? userInput = Console.ReadLine();
                var result = currentMenu.HandleInput(userInput);

                HandleResult(result);
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }

        private void HandleResult(MenuResult result)
        {
            switch (result)
            {
                case MenuResult.Stay:
                    // Do nothing—loop will show menu again
                    break;
                case MenuResult.Back:
                    if (_menuStack.Count > 1)
                    {
                        _menuStack.Pop();  // Pop current, reveal previous
                    }
                    else
                    {
                        Console.WriteLine("Already at top level. Press any key.");
                        Console.ReadKey();
                    }
                    break;
                case MenuResult.Switch:
                    // For now, infer switch based on current menu; enhance with input parsing
                    if (_menuStack.Peek() is MainMenu)
                    {
                        // From main, "1" switches to behavioral
                        PushMenu("behavioral");
                    }
                    // Add more logic for other switches
                    break;
                case MenuResult.Exit:
                    while (_menuStack.Count > 0)
                    {
                        _menuStack.Pop();
                    }
                    break;
            }
        }

        private void PushMenu(string menuKey)
        {
            if (_availableMenus.TryGetValue(menuKey, out var menu))
            {
                _menuStack.Push(menu);
            }
        }
    }
}
