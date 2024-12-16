namespace Common.Models.Pagination
{
    public class TreeNode<T>
    {
        public required T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }
}
