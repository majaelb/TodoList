using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Cli
{
    internal class App
    {
        private readonly ITodoList _todoList;
        private readonly IUserInteraction _userInteraction;

        public App(
            ITodoList todoList,
            IUserInteraction userInteraction)
        {
            _todoList = todoList;
            _userInteraction = userInteraction;
        }

        internal void Start()
        {
            bool runprogram = true;
            while (runprogram)
            {
                PrintChoiceMenu();
                var todos = _todoList.GetTodos();
                _userInteraction.DisplayMessage("MY TASKS");
                PrintTodoList(todos);
                var key = _userInteraction.GetKeyInput();
                runprogram = ExecuteChoice(runprogram, key);
                _userInteraction.ClearConsole();
            }
        }
        private bool ExecuteChoice(bool runProgram, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    var title = _userInteraction.GetStringInput("What needs to be done? ");
                    var description = _userInteraction.GetStringInput("Add a description, how/when? ");
                    _todoList.AddTodo(title, description);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    var index = _userInteraction.GetIntInput("Choose index to mark as complete");
                    try
                    {
                        var todoItemToUpdate = _todoList.GetTodoItemByIndex(index);
                        _todoList.UpdateTodoStatusToComplete(todoItemToUpdate);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _userInteraction.DisplayMessage(ex.Message);
                        _userInteraction.GetKeyInput();
                    }
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    index = _userInteraction.GetIntInput("Choose index to mark as incomplete");
                    try
                    {
                        var todoItem = _todoList.GetTodoItemByIndex(index);
                        _todoList.UpdateTodoStatusToInComplete(todoItem);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _userInteraction.DisplayMessage(ex.Message);
                        _userInteraction.GetKeyInput();
                    }
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    var completeTodos = _todoList.GetCompleteTodos();
                    _userInteraction.DisplayMessage("COMPLETE TASKS");
                    PrintTodoList(completeTodos);
                    _userInteraction.GetKeyInput();
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    var inCompleteTodos = _todoList.GetIncompleteTodos();
                    _userInteraction.DisplayMessage("INCOMPLETE TASKS");
                    PrintTodoList(inCompleteTodos);
                    _userInteraction.GetKeyInput();
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    index = _userInteraction.GetIntInput("Choose index to remove ");
                    try
                    {
                        _todoList.RemoveTodo(index);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _userInteraction.DisplayMessage(ex.Message);
                        _userInteraction.GetKeyInput();
                    }
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    runProgram = false;
                    break;
            }
            return runProgram;
        }
        private void PrintChoiceMenu()
        {
            _userInteraction.DisplayMessage($"""
                   -------------------------
                   CHOOSE ACTION
                   -------------------------
                   1 - Add new task
                   2 - Mark as complete
                   3 - Mark as incomplete
                   4 - View complete tasks
                   5 - View incomplete tasks
                   6 - Remove task

                   9 - Exit
                   -------------------------
                   """);
        }
        private void PrintTodoList(List<TodoItem> todoList)
        {
            int index = 0;
            _userInteraction.DisplayMessage("-----------------------------------------------------------------------------------");
            foreach (var todo in todoList)
            {
                _userInteraction.DisplayMessage($"{index}           {todo.Title}           {todo.Description}               {(todo.IsComplete ? "Done" : "Not Done")}");
                index++;
            }
            _userInteraction.DisplayMessage("-----------------------------------------------------------------------------------");
        }
    }
}
