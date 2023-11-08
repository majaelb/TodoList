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

        public void RemoveTodoItem(Guid guid)
        {
            var todoitem = TodoItems.Where(x => x.Id == guid).FirstOrDefault();

            TodoItems.Remove(todoitem);
        }

        public void SaveTodoItem(TodoItem todoItem) => TodoItems.Add(todoItem);

    }
}
