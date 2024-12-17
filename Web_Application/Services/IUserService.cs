using Ardalis.Result;
using Common.Models.Domain;
using Common.Models.DTO;

namespace Web_Application.Services
{
    public interface IUserService
    {
        Result<User> GetUserById(Guid id);

        Result<IEnumerable<User>> GetUsers();

        Result<Common.Models.Pagination.PagedResult<User>> GetUsersPaginated(int page = 1, int pageSize = 10);

        Result<User> CreateUser (CreateUserDto createUserDto);
    }
}
