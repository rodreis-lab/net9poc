namespace Common.Models.Contracts
{
    public interface IHasParentId
    {
        public Guid? ParentId { get; set; }
    }
}
