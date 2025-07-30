using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class StudentRepository : IStudentRepository
{
    private readonly BotContext _context;
    
    public StudentRepository(BotContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        var students = await _context
            .Students
            .OrderBy(s => s.FullName)
            .ToListAsync();
        
        return students;
    }
    
    public async Task<Student?> GetStudent(int studentId)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == studentId);
        
        return student;
    }

    public async Task AddStudent(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
    }

    public async Task DeleteStudent(int studentId)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (student != null)
        {
            _context.Students.Remove(student);    
        }
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}