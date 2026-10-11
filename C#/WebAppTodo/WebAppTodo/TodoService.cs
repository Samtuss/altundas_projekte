namespace WebAppTodo
{
    public class TodoService
    {
        private readonly List<Todo> _todos;
        private int _nextId = 4;

        public TodoService()
        {
            _todos =
            [
                new Todo { Id = 1, Title = "Hausübung machen", Done = false },
            new Todo { Id = 2, Title = "Einkaufen gehen", Done = true },
            new Todo { Id = 3, Title = "Sport treiben", Done = false },
        ];
        }

        public IReadOnlyList<Todo> GetAll() => _todos;

        public Todo? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public Todo Add(string title)
        {
            var todo = new Todo { Id = _nextId++, Title = title, Done = false };
            _todos.Add(todo);
            return todo;
        }

        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo is null) return false;
            _todos.Remove(todo);
            return true;
        }

        // Erweiterung 1
        public IReadOnlyList<Todo> GetDone() => _todos.Where(t => t.Done).ToList();

        // Erweiterung 2
        public bool MarkDone(int id)
        {
            var todo = GetById(id);
            if (todo is null) return false;
            todo.Done = true;
            return true;
        }
    }
}
