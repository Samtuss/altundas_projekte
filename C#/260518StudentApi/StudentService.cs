namespace StudentApi;

public class StudentService
{
    private readonly List<string> _students = ["Anna", "Ben", "Clara"];

    public IReadOnlyList<string> GetAll() => _students;

    public string? GetById(int id) =>
        id >= 0 && id < _students.Count ? _students[id] : null;

    public void Add(string name) => _students.Add(name);
}