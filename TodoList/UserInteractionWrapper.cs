﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class UserInteractionWrapper : IUserInteraction
    {
        public void DisplayToUser(string s)
        {
            Console.WriteLine(s);
        }

        public string GetUserChoice()
        {
            var choice = Console.ReadLine();

            return choice.ToLower();
        }

        public string GetUserInput(string instruction)
        {
            Console.WriteLine(instruction);

            var input = Console.ReadLine();

            //if (!input.Any())
            //    throw new InvalidOperationException("Du måste ange en titel");

            return input;
        }

        public void PrintChoiceMenu()
        {
            Console.WriteLine($"""
                   ---------------
                   CHOOSE ACTION
                   ---------------
                   A - Add new task
                   R - Remove task
                   M - Mark as complete
                   N - Mark as incomplete
                   V - View all tasks
                   C - View complete tasks
                   I - View incomplete tasks

                   X - Exit
                   ---------------
                   """);
        }

        public void PrintTodoList(List<TodoItem> todoList)
        {
            int count = 0;
            Console.WriteLine("Index           Title           Description         Done");
            foreach (var todo in todoList)
            {
                Console.WriteLine($"{count}               {todo.Title}      {todo.Description}              {(todo.IsComplete ? "Done" : "Not Done")}");
                count++;
            }
        }

    }
}
