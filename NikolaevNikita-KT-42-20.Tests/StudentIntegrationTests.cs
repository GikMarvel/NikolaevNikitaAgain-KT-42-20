
using Microsoft.EntityFrameworkCore;
using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Filters.StudentFilters;
using NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces;
using NikolaevNikita_KT_42_20.Models;
using NikolaevNikita_KT_42_20.ServiceExtensions;



namespace NikolaevNikita_KT_42_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            //var groups = new List<Group>
            //{
            //    new Group
            //    {
            //        GroupName = "KT-31-20"
            //    },
            //    new Group
            //    {
            //        GroupName = "KT-41-20"
            //    }
            //};
            //await ctx.Set<Group>().AddRangeAsync(groups);

            //var students = new List<Student>
            //{
            //    new Student
            //    {
            //        Surname = "Ivanov",
            //        Name = "asdf",
            //        Midname = "zxc",
            //        GroupId = 1,
            //        IsDeleted = false
            //    },
            //    new Student
            //    {
            //        Surname = "qwerty2",
            //        Name = "asdf2",
            //        Midname = "zxc2",
            //        GroupId = 2,
            //        IsDeleted = false
            //    },
            //    new Student
            //    {
            //        Surname = "qwerty3",
            //        Name = "asdf3",
            //        Midname = "zxc3",
            //        GroupId = 1,
            //        IsDeleted = false
            //    }
            //};
            //await ctx.Set<Student>().AddRangeAsync(students);

            //await ctx.SaveChangesAsync();

            // Act
            var filter = new StudentGroupFilter
            {
                GroupName = "KT-31-20"
            };

            //var filter2 = new StudentFIOFilter
            //{
            //    Surname = "Ivanov"
            //};
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
        [Fact]
        public async Task GetStudentsBySurnameAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupName = "KT-41-20"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    Surname = "Ivanov",
                    Name = "asdf",
                    Midname = "zxc",
                    GroupId = 1,
                    IsDeleted = false
                },
                new Student
                {
                    Surname = "Ivanov",
                    Name = "asdf2",
                    Midname = "zxc2",
                    GroupId = 2,
                    IsDeleted = false
                },
                new Student
                {
                    Surname = "qwerty3",
                    Name = "asdf3",
                    Midname = "zxc3",
                    GroupId = 1,
                    IsDeleted = false
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
         

            var filter = new StudentFIOFilter
            {
                Surname = "Ivanov"
            };
            var studentsResult = await studentService.GetStudentsByIsSurnameAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);


            var filter1 = new StudentGroupFilter
            {
                GroupName = "KT-31-20"
            };

            var studentsResult1 = await studentService.GetStudentsByGroupAsync(filter1, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult1.Length);
        }
    }
}