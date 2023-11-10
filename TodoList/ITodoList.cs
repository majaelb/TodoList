namespace TodoList
{
    public interface ITodoList
    {
        TodoItem AddTodo(string title, string description);
        List<TodoItem> GetCompleteTodos();
        List<TodoItem> GetIncompleteTodos();
        TodoItem GetTodoItemByIndex(int index);
        List<TodoItem> GetTodos();
        void RemoveTodo(int index);
        TodoItem UpdateTodoStatusToComplete(TodoItem todoItem);
        TodoItem UpdateTodoStatusToInComplete(TodoItem todoItem);
    }
}