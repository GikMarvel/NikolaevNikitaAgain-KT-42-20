using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using NikolaevNikita_KT_42_20.Filters.GroupFilters;

namespace NikolaevNikita_KT_42_20.Interfaces.IGroupInterfaces
{
    public interface IGroupService
    {
        public Task<Group[]> GetGroupsByYearAsync(GroupYearFilter filter, CancellationToken cancellationToken);
        public Task<Group[]> GetGroupsByDeletedAsync(GroupIsDeletedFilter filter, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        private readonly StudentDbContext _dbContext;
        public GroupService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Group[]> GetGroupsByYearAsync(GroupYearFilter filter, CancellationToken cancellationToken = default)
        {
            var groups = _dbContext.Set<Group>().Where(w => w.GroupYear == filter.GroupYear).ToArrayAsync(cancellationToken);

            return groups;
        }

        public Task<Group[]> GetGroupsByDeletedAsync(GroupIsDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var groups = _dbContext.Set<Group>().Where(w => w.IsDeleted == filter.GroupIsDeleted).ToArrayAsync(cancellationToken);

            return groups;
        }


    }
}
