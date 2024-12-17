using Common.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public TestDbContext() : base(GetInMemoryOptions())
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        private static DbContextOptions<TestDbContext> GetInMemoryOptions()
        {
            // Generate a unique database name for each instance
            return new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase($"InMemoryDb_{Guid.CreateVersion7()}")
                .Options;
        }
    }
}
