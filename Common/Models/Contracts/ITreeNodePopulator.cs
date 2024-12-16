using Common.Models.Pagination;

namespace Common.Models.Contracts
{
    public interface ITreeNodePopulator<T>
        where T : IHasId, IHasParentId
    {
        List<TreeNode<T>> PopulateTreeNode(List<T> list, Guid? parentId);
    }
}
