using Domain;

namespace Application.Interfaces;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetStudents();
    public Task<Student?> GetStudent(int studentId);
    public Task AddStudent(Student student);
    public void UpdateStudent(Student student);
    public Task DeleteStudent(int studentId);
    public Task SaveChanges();
}