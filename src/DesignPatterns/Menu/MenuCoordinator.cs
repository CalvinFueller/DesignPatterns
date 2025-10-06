using System.Reflection;

namespace DesignPatterns.Menu
{
    public class MenuCoordinator
    {
        private readonly Stack<IMenu> _menuStack = new();
        private readonly Dictionary<MenuEnum, IMenu> _availableMenus = [];

        public MenuCoordinator()
        {
            RegisterMenus();
            PushMenu(MenuEnum.Main);  // Start with main menu
        }

        private void RegisterMenus()
        {
            // Auto-discover: Scan current assembly for [MenuKey] classes implementing IMenu
            var menuTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IMenu)) &&
                            t.GetCustomAttribute<MenuKeyAttribute>() != null)
                .ToList();

            foreach (var type in menuTypes)
            {
                var keyAttr = type.GetCustomAttribute<MenuKeyAttribute>();
                if (keyAttr != null)
                {
                    var menu = (IMenu)Activator.CreateInstance(type)!;
                    _availableMenus[keyAttr.Key] = menu;
                }
            }
        }

        public void Run()
        {
            while (_menuStack.Count > 0)
            {
                var currentMenu = _menuStack.Peek();
                currentMenu.Show();

                string? userInput = Console.ReadLine();
                var result = currentMenu.HandleInput(userInput!);

                HandleResult(result);
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }

        private void HandleResult(MenuResult result)
        {
            switch (result.Type)
            {
                case ResultType.Stay:
                    // Do nothing—loop will show menu again
                    break;
                case ResultType.Back:
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
                case ResultType.Switch:
                    if (result.Target.HasValue)
                    {
                        PushMenu(result.Target.Value);
                    }
                    else
                    {
                        Console.WriteLine("No target menu specified for switch. Press any key.");
                        Console.ReadKey();
                    }
                    break;
                case ResultType.Exit:
                    while (_menuStack.Count > 0)
                    {
                        _menuStack.Pop();
                    }
                    break;
            }
        }

        private void PushMenu(MenuEnum type)
        {
            if (_availableMenus.TryGetValue(type, out var menu))
            {
                _menuStack.Push(menu);
            }
            else
            {
                Console.WriteLine($"Menu '{type}' not found. Press any key.");
                Console.ReadKey();
            }
        }
    }
}
