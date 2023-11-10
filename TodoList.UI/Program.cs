using TodoList.Cli;

namespace TodoList.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();
            var todo = new TodoList(storage);
            var consoleWrapper = new ConsoleWrapper();
            var ui = new UserInteraction(consoleWrapper);

            var app = new App(todo, ui);

            app.Start();
        }
    }
}