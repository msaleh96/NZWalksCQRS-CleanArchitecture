namespace API.Common;

public class ApiError
{
    public string Code { get; set; } = default!;
    public string Message { get; set; } = default!;
}

public class ApiResponse<T>
{
    public bool IsValid { get; set; }
    public List<ApiError> Errors { get; set; } = [];
    public T? Data { get; set; }
}