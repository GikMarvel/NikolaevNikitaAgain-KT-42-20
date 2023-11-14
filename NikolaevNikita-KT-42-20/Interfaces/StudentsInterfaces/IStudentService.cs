using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Filters;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
            public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
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
    }
}
