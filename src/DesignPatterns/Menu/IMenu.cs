namespace DesignPatterns.Menu
{
    internal interface IMenu
    {
        void Show();  // Display the menu options
        MenuResult HandleInput(string input);  // Process user choice; return next action/state
    }

    /// <summary>
    /// Enum for navigation results (keeps it type-safe)
    /// </summary>
    public enum MenuResult
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
}
