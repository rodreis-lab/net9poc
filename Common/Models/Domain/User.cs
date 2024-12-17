using Common.Enums;
using Common.Models.Contracts;
using Common.Models.DTO;

namespace Common.Models.Domain
{
    public class User : IHasId
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public Colors FavoriteColor { get; set; }

        public int YearsOfWork { get; set; }

        public User(Guid id, string name, string email, bool isActive, Colors favoriteColor, int yearsOfWork)
        {
            Id = id;
            Name = name;
            Email = email;
            IsActive = isActive;
            FavoriteColor = favoriteColor;
            YearsOfWork = yearsOfWork;
        }

        public User(CreateUserDto createUserDto)
        {
            Id = Guid.CreateVersion7();
            Name = createUserDto.Name;
            Email = createUserDto.Email;
            IsActive = createUserDto.IsActive;
            FavoriteColor = createUserDto.FavoriteColor;
            YearsOfWork = createUserDto.YearsOfWork;
        }
    }
}
