using Common.Models.Contracts;
using Common.Models.Pagination;

namespace Common.Helpers
{
    public sealed class TreeNodePopulator<T> : ITreeNodePopulator<T>
        where T : IHasId, IHasParentId
    {
        public List<TreeNode<T>> PopulateTreeNode(List<T> list, Guid? parentId)
        {
            return list
                .Where(c => c.ParentId == parentId)
                .Select(c => new TreeNode<T>
                {
                    Value = c,
                    Children = PopulateTreeNode(list, c.Id)
                })
            .ToList();
        }
    }
}
