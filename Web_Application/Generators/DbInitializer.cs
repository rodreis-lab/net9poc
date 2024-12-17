using Common;
using Web_Application.Generators.Categories;
using Web_Application.Generators.Users;

namespace Web_Application.Generators
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TestDbContext>();

            context.Database.EnsureCreated();

            var fakeUsers = new UserGenerator().GetFaker().Generate(1000);
            var fakeCategories = new CategoryGenerator().GetFaker().Generate(1000);

            context.Users.AddRange(fakeUsers);
            context.Categories.AddRange(fakeCategories);
            context.SaveChanges();
        }
    }
}
