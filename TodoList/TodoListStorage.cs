using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoListStorage : ITodoListStorage
    {
        public static List<TodoItem> TodoItems { get; set; }

        public TodoListStorage()
        {
            TodoItems = new List<TodoItem>();
        }

        public List<TodoItem> GetAllTodos() => TodoItems;

        public void RemoveTodoItem(int index) => TodoItems.RemoveAt(index);

        public void SaveTodoItem(TodoItem todoItem)
        {
            var item = TodoItems.FirstOrDefault(x => x.Id == todoItem.Id);
            if (item == null)
            {
                TodoItems.Add(todoItem);
            }
            else
            {
                // update list in database
            }


        }

    }
}
