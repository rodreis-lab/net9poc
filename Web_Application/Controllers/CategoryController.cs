using Ardalis.Result.AspNetCore;
using Common.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Services;
using Common.Models.Pagination;

namespace Web_Application.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = "Get Categories Paginated")]
        public ActionResult<Common.Models.Pagination.PagedResult<TreeNode<Category>>> GetCategoriesPaginated(int page = 1, int pageSize = 10)
        {
            return this.ToActionResult(_categoryService.GetCategoriesPaginated(page, pageSize));
        }
    }
}
