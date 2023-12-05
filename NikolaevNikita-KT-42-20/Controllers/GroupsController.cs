using NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces;
using NikolaevNikita_KT_42_20.Models;
using NikolaevNikita_KT_42_20.Database;
using Microsoft.AspNetCore.Mvc;
using NikolaevNikita_KT_42_20.Filters.StudentFilters;
using NikolaevNikita_KT_42_20.Filters.GroupFilters;
using NikolaevNikita_KT_42_20.Interfaces.IGroupInterfaces;

namespace NikolaevNikita_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGroupService _groupService;
        private StudentDbContext _context;

        public GroupsController(ILogger<GroupsController> logger, IGroupService groupService, StudentDbContext context)
        {
            _logger = logger;
            _groupService = groupService;
            _context = context;
        }

        [HttpPost("GetGroupsByYear")]
        public async Task<IActionResult> GetGroupsByYearAsync(GroupYearFilter filter, CancellationToken cancellationToken = default)
        {
            var groups = await _groupService.GetGroupsByYearAsync(filter, cancellationToken);

            return Ok(groups);
        }

        [HttpPost("GetGroupsByDeletedGroup")]
        public async Task<IActionResult> GetStudentsByIsDeletedAsync(GroupIsDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _groupService.GetGroupsByDeletedAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("AddGroup", Name = "AddGroup")]
        public IActionResult CreateGroup([FromBody] NikolaevNikita_KT_42_20.Models.Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Groups.Add(group);
            _context.SaveChanges();
            return Ok(group);
        }

        [HttpPut("EditGroup")]
        public IActionResult UpdateGroup(string groupname, [FromBody] StudentGroupFilter updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupname);

            if (existingGroup == null)
            {
                return NotFound();
            }

            existingGroup.GroupName = updatedGroup.GroupName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteGroup")]
        public IActionResult DeleteGroup(string groupName, NikolaevNikita_KT_42_20.Models.Group updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupName);

            if (existingGroup == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(existingGroup);
            _context.SaveChanges();

            return Ok();
        }
    }
}