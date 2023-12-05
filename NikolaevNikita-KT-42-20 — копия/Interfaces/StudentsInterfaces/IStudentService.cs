using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Filters;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);
        public Task CreateStudent(Student student);
        public Task DeleteStudent(Student student);
        public Task UpdateStudent(Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.StudentName).ToArrayAsync(cancellationToken);
            return students;
        }

        public async Task CreateStudent(Student Student)
        {
            _dbContext.Students.Add(Student);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteStudent(Student Student)
        {
            _dbContext.Students.Remove(Student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student Student)
        {
            _dbContext.Entry(Student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
