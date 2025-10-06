namespace DesignPatterns.Menu
{
    public interface IMenu
    {
        void Show();  // Display the menu options
        MenuResult HandleInput(string input);  // Process user choice; return next action/state
    }

    /// <summary>
    /// Enum for navigation results (keeps it type-safe)
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// Continue in current menu
        /// </summary>
        Stay,
        /// <summary>
        /// Go back to previous menu
        /// </summary>
        Back,
        /// <summary>
        /// Switch to a specific menu (use with NextMenu property)
        /// </summary>
        Switch,
        /// <summary>
        /// End the app
        /// </summary>
        Exit
    }

    public class MenuResult
    {
        public ResultType Type { get; }
        public MenuEnum? Target { get; }  // Optional for Switch

        public MenuResult(ResultType type, MenuEnum? target = null)
        {
            Type = type;
            Target = target;
        }

        // Factory methods
        public static MenuResult Stay() => new(ResultType.Stay);
        public static MenuResult Back() => new(ResultType.Back);
        public static MenuResult Exit() => new(ResultType.Exit);
        public static MenuResult SwitchTo(MenuEnum target) => new(ResultType.Switch, target);
    }


}
