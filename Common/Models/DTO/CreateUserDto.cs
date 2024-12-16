using Common.Enums;

namespace Common.Models.DTO
{
    public class CreateUserDto
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public Colors FavoriteColor { get; set; }

        public int YearsOfWork { get; set; }
    }
}
