using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Common.Helpers;

namespace Common.Extensions
{
    public static class GuardExtensions
    {
        public static void CollectIfNull<T>(
        this IGuardClause guardClause,
        T input,
        string parameterName,
        ValidationErrorCollector errorCollector)
        {
            if (input == null)
            {
                errorCollector.AddError($"{parameterName} cannot be null.");
            }
        }

        public static void CollectIfOutOfRange<T>(
            this IGuardClause guardClause,
            T input,
            string parameterName,
            T minValue,
            T maxValue,
            ValidationErrorCollector errorCollector) where T : IComparable
        {
            if (input.CompareTo(minValue) < 0 || input.CompareTo(maxValue) > 0)
            {
                errorCollector.AddError($"{parameterName} must be between {minValue} and {maxValue}.");
            }
        }

        public static void CollectIfInvalidInput<T>(
      this IGuardClause guardClause,
      T input,
      string parameterName,
      Func<T, bool> predicate,
      ValidationErrorCollector errorCollector,
      string? errorMessage = null)
        {
            if (!predicate(input))
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} is invalid.");
            }
        }

        public static void CollectIfInvalidFormat(
            this IGuardClause guardClause,
            string input,
            string parameterName,
            string regexPattern,
            ValidationErrorCollector errorCollector,
            string? errorMessage = null)
        {
            if (!Regex.IsMatch(input, regexPattern))
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} has an invalid format.");
            }
        }

        public static void CollectIfDefault<T>(
            this IGuardClause guardClause,
            T input,
            string parameterName,
            ValidationErrorCollector errorCollector,
            string? errorMessage = null) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(input, default))
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} cannot have the default value.");
            }
        }

        public static void CollectIfStringTooShort(
            this IGuardClause guardClause,
            string input,
            string parameterName,
            int minLength,
            ValidationErrorCollector errorCollector,
            string? errorMessage = null)
        {
            if (input.Length < minLength)
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} must be at least {minLength} characters long.");
            }
        }

        public static void CollectIfStringTooLong(
            this IGuardClause guardClause,
            string input,
            string parameterName,
            int maxLength,
            ValidationErrorCollector errorCollector,
            string? errorMessage = null)
        {
            if (input.Length > maxLength)
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} must be no more than {maxLength} characters long.");
            }
        }

        public static void CollectIfEnumOutOfRange<T>(
            this IGuardClause guardClause,
            T input,
            string parameterName,
            ValidationErrorCollector errorCollector,
            string? errorMessage = null) where T : struct, Enum
        {
            if (!Enum.IsDefined(typeof(T), input))
            {
                errorCollector.AddError(errorMessage ?? $"{parameterName} has an invalid value.");
            }
        }
    }
}
