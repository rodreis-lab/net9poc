using Ardalis.GuardClauses;
using Common.Extensions;
using Common.Helpers;
using Common.Models.Contracts;
using Common.Models.Domain;

namespace Common.Models.Validators
{
    public class UserValidator : IValidator<User>
    {
        public void Validate(User user, ValidationErrorCollector errorCollector)
        {
            Guard.Against.CollectIfNull(user.Id, nameof(user.Id), errorCollector);

            Guard.Against.CollectIfInvalidInput(user.ParentId, nameof(user.ParentId), pId => pId != user.Id, errorCollector,  "Id and parent id must be different.");

            Guard.Against.CollectIfInvalidFormat(user.Email, nameof(user.Email), @"^[^@]+@[^@]+\.[^@]+$", errorCollector);
            
            Guard.Against.CollectIfStringTooShort(user.Name, nameof(user.Name), 3, errorCollector, "Name has a minimum char length of 3.");
            Guard.Against.CollectIfStringTooLong(user.Name, nameof(user.Name), 15, errorCollector, "Name has a maximum char length of 15.");

            Guard.Against.CollectIfEnumOutOfRange(user.FavoriteColor, nameof(user.FavoriteColor), errorCollector);

            Guard.Against.CollectIfOutOfRange(user.YearsOfWork, nameof(user.YearsOfWork), 0, 30, errorCollector);
        }
    }
}
