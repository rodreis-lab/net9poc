using Common.Enums;
using Common.Models.Contracts;
using Common.Models.DTO;

namespace Common.Models.Domain
{
    public class User : IHasId, IHasParentId
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? CompleteFamilyName { get; set; }

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public Colors FavoriteColor { get; set; }

        public int YearsOfWork { get; set; }

        public User(Guid id, Guid? parentId, string name, string? completeFamilyName, string email, bool isActive, Colors favoriteColor, int yearsOfWork)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            CompleteFamilyName = completeFamilyName;
            Email = email;
            IsActive = isActive;
            FavoriteColor = favoriteColor;
            YearsOfWork = yearsOfWork;
        }

        public User(CreateUserDto createUserDto)
        {
            Id = Guid.CreateVersion7();
            ParentId = createUserDto.ParentId;
            Name = createUserDto.Name;
            Email = createUserDto.Email;
            IsActive = createUserDto.IsActive;
            FavoriteColor = createUserDto.FavoriteColor;
            YearsOfWork = createUserDto.YearsOfWork;
        }
    }
}
