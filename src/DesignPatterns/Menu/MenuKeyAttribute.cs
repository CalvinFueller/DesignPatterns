namespace DesignPatterns.Menu
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MenuKeyAttribute : Attribute
    {
        public MenuEnum Key { get; }
        public MenuKeyAttribute(MenuEnum key)
        {
            Key = key;
        }
    }
}
