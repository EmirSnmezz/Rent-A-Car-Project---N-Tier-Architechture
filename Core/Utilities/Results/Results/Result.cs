using Core.Utilities.Results.Result.Result;

namespace Core.Utilities.Results.Result.Result;
public class Result : Results.Result.Result.IResult
{
    public Result(bool isSucess, string message) : this(isSucess)
    {
        Message = message;
    }

    public Result(bool isSucess)
    {
        IsSuccess = isSucess;
    }

    public string Message { get; }
    public bool IsSuccess { get; }
}
