using Bogus;
using Common.Models.Domain;

namespace Web_Application.Generators.Categories
{
    public class CategoryGenerator
    {
        private readonly Faker<Category> _faker;
        private readonly List<Category> _existingCategories;

        public CategoryGenerator()
        {
            _faker = new Faker<Category>()
                .CustomInstantiator(f => GenerateCategory(f, null));

            _existingCategories = new List<Category>();
        }

        private Category GenerateCategory(Faker f, Guid? parentId)
        {
            string name = f.Company.CompanyName();

            Guid? currentParentId = parentId ?? (f.Random.Bool() ? _existingCategories.Any() ? _existingCategories[f.Random.Int(0, _existingCategories.Count - 1)].Id : (Guid?)null : (Guid?)null);

            string fqName = GenerateCategoryFqName(f, currentParentId, name);

            var user = new Category
            {
                Id = Guid.CreateVersion7(),
                Name = name,
                FqName = fqName,
                ParentId = currentParentId,
            };

            _existingCategories.Add(user);

            return user;
        }

        private string GenerateCategoryFqName(Faker f, Guid? parentId, string currentCatName)
        {
            if (!parentId.HasValue)
            {
                return currentCatName;
            }

            var parentName = _existingCategories.FirstOrDefault(c => c.Id == parentId.Value);

            return parentName != null
                ? $"{parentName.FqName} {currentCatName}"
                : currentCatName;
        }

        public Faker<Category> GetFaker()
        {
            return _faker;
        }
    }
}
