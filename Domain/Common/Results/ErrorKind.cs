namespace Domain.Common.Results;

public enum ErrorKind
{
    Validation,
    Failure,
    Unexpected,
    NotFound,
    Conflict,
    Unauthorized,
    Forbidden,
    InternalServerError
}
