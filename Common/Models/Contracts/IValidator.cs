using Common.Helpers;

namespace Common.Models.Contracts
{
    public interface IValidator<T>
    {
        void Validate(T dto, ValidationErrorCollector errorCollector);
    }
}
