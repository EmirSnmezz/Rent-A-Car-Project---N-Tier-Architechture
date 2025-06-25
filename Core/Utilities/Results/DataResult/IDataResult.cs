using Core.Utilities.Results.Result.Result;

namespace Core.Utilities.Results.DataResult
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
