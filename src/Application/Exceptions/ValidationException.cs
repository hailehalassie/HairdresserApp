namespace Application.Exceptions
{ 
    public class ValidationException : AppException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException(IDictionary<string, string[]> errors)
            : base("One or more validation errors occured.", 400)
        {
            Errors = errors;
        }
    }
}