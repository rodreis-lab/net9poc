using Common.Models.Contracts;

namespace Common.Models.Domain
{
    public class Category : IHasId, IHasParentId
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? FqName { get; set; }
    }
}
