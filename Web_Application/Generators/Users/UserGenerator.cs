using Bogus;
using Common.Enums;
using Common.Models.Domain;

namespace Web_Application.Generators.Users
{
    public class UserGenerator
    {
        private readonly Faker<User> _faker;
        private readonly List<User> _existingUsers;

        public UserGenerator()
        {
            _faker = new Faker<User>()
                .CustomInstantiator(GenerateUser);

            _existingUsers = new List<User>();
        }

        private User GenerateUser(Faker f)
        {
            var user = new User(
                id: Guid.CreateVersion7(),
                name: f.Name.FullName(),
                email: f.Internet.Email(),
                isActive: f.Random.Bool(),
                favoriteColor: f.PickRandom<Colors>(),
                yearsOfWork: f.Random.Int(0, 30));

            _existingUsers.Add(user);

            return user;
        }

        public Faker<User> GetFaker()
        {
            return _faker;
        }
    }
}
