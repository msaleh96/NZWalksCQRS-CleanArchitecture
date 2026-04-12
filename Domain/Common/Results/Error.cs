namespace Domain.Common.Results;

public readonly record struct Error
{
    private Error(string code, string description, ErrorKind type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public string Code { get; }
    public string Description { get; }  
    public ErrorKind Type { get; }

    public static Error Validation(string code = nameof(Validation), string description = "Validation failed") => new(code, description, ErrorKind.Validation);
    public static Error Failure(string code = nameof(Failure), string description = "Operation failed") => new(code, description, ErrorKind.Failure);
    public static Error Unexpected(string code = nameof(Unexpected), string description = "An unexpected error occurred") => new(code, description, ErrorKind.Unexpected);
    public static Error NotFound(string code = nameof(NotFound), string description = "Resource not found") => new(code, description, ErrorKind.NotFound);
    public static Error Conflict(string code = nameof(Conflict), string description = "Resource conflict") => new(code, description, ErrorKind.Conflict);
    public static Error Unauthorized(string code = nameof(Unauthorized), string description = "Unauthorized access") => new(code, description, ErrorKind.Unauthorized);
    public static Error Forbidden(string code = nameof(Forbidden), string description = "Access forbidden") => new(code, description, ErrorKind.Forbidden);
    public static Error InternalServerError(string code = nameof(InternalServerError), string description = "Internal server error") => new(code, description, ErrorKind.InternalServerError);
}