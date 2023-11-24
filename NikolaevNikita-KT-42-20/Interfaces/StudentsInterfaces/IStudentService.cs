using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Filters.StudentFilters;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByIsDeletedAsync(StudentIsDeletedFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByIsSurnameAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default);
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
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).Where(w => w.IsDeleted == filter.StudentIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => (w.Surname == filter.Surname) || (w.Name == filter.Name) || (w.Midname == filter.Midname)).Where(w => w.IsDeleted == filter.StudentIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByIsDeletedAsync(StudentIsDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.IsDeleted == filter.StudentIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByIsSurnameAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Surname == filter.Surname).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
