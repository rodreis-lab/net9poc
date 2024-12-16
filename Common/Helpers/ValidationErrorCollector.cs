namespace Common.Helpers
{
    public class ValidationErrorCollector
    {
        private readonly List<string> _errors = new();

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public bool HasErrors => _errors.Any();

        public IReadOnlyList<string> GetErrors() => _errors.AsReadOnly();
    }
}
