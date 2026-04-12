using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Domain.Common.Results;

public static class Result
{
    public static Success Success => default;
    public static Created Created => default;
    public static Deleted Deleted => default;
    public static Updated Updated => default;
}

public sealed class Result<TValue> : IResult<TValue>
{
    private readonly TValue _value = default!;
    private readonly List<Error> _errors = [];

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;

    public List<Error> Errors => IsError ? _errors : [];
    public TValue Value => IsSuccess ? _value : default!;
    public Error TopError => IsError && _errors.Count > 0 ? _errors[0] : default!;

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serialization only", true)]
    public Result(TValue value, List<Error> errors, bool isSuccess)
    {
        if (isSuccess)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null for a successful result");
            _errors = [];
            IsSuccess = true;
        }
        else
        {
            if (errors is null || errors.Count == 0)
            {
                throw new ArgumentException("Errors cannot be null or empty for a failed result", nameof(errors));
            }
            _value = default!;
            _errors = errors;
            IsSuccess = false;
        }
    }

    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<List<Error>, TNextValue> onError)
        => IsSuccess ? onValue(Value) : onError(Errors);
    private Result(Error error)
    {
        _errors = [error];
    }

    private Result(List<Error> errors)
    { 

        if (errors is null || errors.Count ==0)
        {
            throw new ArgumentException("Errors cannot be null or empty", nameof(errors));
        }

        _errors = errors;
        IsSuccess = false;
    }

    private Result(TValue value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value), "Value cannot be null");

        _value = value;
        IsSuccess = true;
    }

    public static implicit operator Result<TValue>(TValue value) => new(value);

    public static implicit operator Result<TValue>(Error error) => new(error);

    public static implicit operator Result<TValue>(List<Error> errors) => new(errors);
}

public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;
