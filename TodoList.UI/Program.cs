namespace TodoList.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInteractionWrapper();
            var storage = new TodoListStorage();
            var todo = new TodoList(storage);

            ui.PrintChoiceMenu();


            bool runprogram = true;
            while (runprogram)
            {
                var choice = ui.GetUserChoice();
                runprogram = ExecuteChoice(runprogram, choice, ui, todo);
            }

        }

        private static bool ExecuteChoice(bool runProgram, string choice, UserInteractionWrapper ui, TodoList todo)
        {
            switch (choice)
            {
                case "a":
                        var title = ui.GetUserInput("What needs to be done? ");
                        var description = ui.GetUserInput("Add a description, how/when? ");
                        todo.AddTodo(title, description);
                    break;
                case "m":

                case "v":
                    var todos = todo.GetTodos();
                    ui.PrintTodoList(todos);
                    break;
                case "c":
                    var completeTodos = todo.GetCompleteTodos();
                    ui.PrintTodoList(completeTodos);
                    break;
                case "i":
                    var inCompleteTodos = todo.GetIncompleteTodos();
                    ui.PrintTodoList(inCompleteTodos);
                    break;
                default:
                    Console.WriteLine("Not a valid input");
                    break;
                case "x":
                    runProgram = false;
                    break;
            }
            return runProgram;
        }
    }
}