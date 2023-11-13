using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Storage : IStorage
    {
        public static List<TodoItem> TodoItems { get; set; }

        public Storage()
        {
            TodoItems = new List<TodoItem>
            {
                new TodoItem { Title = "Feed cat   ", Description = "Meatballs in refridgerator", IsComplete = true },
                new TodoItem { Title = "Clean house", Description = "Vacuum hallway and bedroom", IsComplete = false },
                new TodoItem { Title = "Study tests", Description = "Finish to do-project today", IsComplete = false },
            };
        }
        public List<TodoItem> GetAllTodos() => TodoItems;
        public void RemoveTodoItem(int index) => TodoItems.RemoveAt(index);
        public void SaveTodoItem(TodoItem todoItem)
        {
            var item = TodoItems.FirstOrDefault(x => x.Id == todoItem.Id);
            if (item == null)            
                TodoItems.Add(todoItem);
        }
    }
}
