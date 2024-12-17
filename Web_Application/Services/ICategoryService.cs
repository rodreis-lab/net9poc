using Ardalis.Result;
using Common.Models.Domain;
using Common.Models.Pagination;

namespace Web_Application.Services
{
    public interface ICategoryService
    {
        Result<Common.Models.Pagination.PagedResult<TreeNode<Category>>> GetCategoriesPaginated(int page = 1, int pageSize = 10);
    }
}
