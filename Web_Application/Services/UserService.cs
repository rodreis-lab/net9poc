using Ardalis.Result;
using Common;
using Common.Helpers;
using Common.Models.Contracts;
using Common.Models.Domain;
using Common.Models.DTO;
using Common.Models.Pagination;

namespace Web_Application.Services
{
    public class UserService : IUserService
    {
        private readonly TestDbContext _dbContext;
        private readonly IValidator<User> _validator;

        public UserService(TestDbContext dbContext, IValidator<User> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Result<User> GetUserById(Guid id)
        {
            if (id == default) return Result<User>.Invalid(new List<ValidationError>
            {
                new ValidationError
                {
                    Identifier = nameof(id),
                    ErrorMessage = "Id is required."
                }
            });

            var user = _dbContext.Users.FirstOrDefault(wf  => wf.Id == id);
            if (user == null) return Result<User>.NotFound($"User with id {id} doesn't exist.");

            return Result<User>.Success(user);
        }

        public Result<IEnumerable<User>> GetUsers()
        {
            return Result<IEnumerable<User>>.Success(_dbContext.Users);
        }

        public Result<Common.Models.Pagination.PagedResult<User>> GetUsersPaginated(int page = 1, int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var totalUsers = _dbContext.Users.ToList();
            int totalCount = totalUsers.Count();

            var pagedUsers = totalUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new Common.Models.Pagination.PagedResult<User>
            {
                Items = pagedUsers,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = page,
            };

            return result;
        }
    
        public Result<User> CreateUser(CreateUserDto createUserDto)
        {
            var errorCollector = new ValidationErrorCollector();

            if (_dbContext.Users.Any(u => u.Email == createUserDto.Email)) errorCollector.AddError("Email is already registered");

            var user = new User(createUserDto);
            _validator.Validate(user, errorCollector);

            if (errorCollector.HasErrors)
                return Result.Error(string.Join("; ", errorCollector.GetErrors()));

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Result<User>.Success(user);
        }
    }
}
