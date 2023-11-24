using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Filters;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace NikolaevNikita_KT_42_20.Interfaces.ICoursesInterfaces
{
    public interface ICoursesInterfaces
    {
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken);
    }

    public class CourseService : ICoursesInterfaces
    {
        private readonly StudentDbContext _dbContext;
        public CourseService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken = default)
        {
            var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return courses;
        }
    }
}
