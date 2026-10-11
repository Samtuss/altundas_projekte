namespace StudentsApiNeu
{
    public class StudentService
    {
        private readonly List<string> _students = ["Anna", "Ben", "Clara"];

        public IReadOnlyList<string> GetAll() => _students;

        public string? GetById(int id)
        {
            if (id < 0 || id >= _students.Count)
            {
                return null;
            }
            return _students[id];
        }
    }
}
