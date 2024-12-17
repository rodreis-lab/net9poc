using Ardalis.Result;
using Common;
using Common.Models.Contracts;
using Common.Models.Domain;
using Common.Models.Pagination;

namespace Web_Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TestDbContext _dbContext;
        private readonly ITreeNodePopulator<Category> _treeNodePopulator;

        public CategoryService(TestDbContext dbContext, ITreeNodePopulator<Category> treeNodePopulator)
        {
            _dbContext = dbContext;
            _treeNodePopulator = treeNodePopulator;
        }

        public Result<Common.Models.Pagination.PagedResult<TreeNode<Category>>> GetCategoriesPaginated(int page = 1, int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var totalCategories = _dbContext.Categories.ToList();
            int totalCount = totalCategories.Count();

            var tree = _treeNodePopulator.PopulateTreeNode(totalCategories, null);

            var pagedCategories = tree.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new Common.Models.Pagination.PagedResult<TreeNode<Category>>
            {
                Items = pagedCategories,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = page,
            };

            return result;
        }
    }
}
