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
                .CustomInstantiator(f => GenerateUser(f, null));

            _existingUsers = new List<User>();
        }

        private User GenerateUser(Faker f, Guid? parentId)
        {
            string name = f.Name.LastName();

            Guid? currentParentId = parentId ?? (f.Random.Bool() ? _existingUsers.Any() ? _existingUsers[f.Random.Int(0, _existingUsers.Count - 1)].Id : (Guid?)null : (Guid?)null);

            string completeFamilyName = GenerateCompleteFamilyName (f, currentParentId, name);

            var user = new User(
                id: Guid.CreateVersion7(),
                name: name,
                email: f.Internet.Email(),
                isActive: f.Random.Bool(),
                favoriteColor: f.PickRandom<Colors>(),
                parentId: currentParentId,
                completeFamilyName: completeFamilyName,
                yearsOfWork: f.Random.Int(0, 30)
                );

            _existingUsers.Add(user);

            return user;
        }

        private string GenerateCompleteFamilyName(Faker f, Guid? parentId, string currentUserName)
        {
            if (!parentId.HasValue)
            {
                return currentUserName;
            }

            var parentName = _existingUsers.FirstOrDefault(c => c.Id == parentId.Value);

            return parentName != null
                ? $"{parentName.CompleteFamilyName} {currentUserName}"
                : currentUserName;
        }

        public Faker<User> GetFaker()
        {
            return _faker;
        }
    }
}
