using Core.Utilities.Results.Result.Result;

namespace Core.Utilities.Results.DataResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message, T data) : base(false, message, data)
        {
            
        }

        public ErrorDataResult(T data) : base(false, data)
        {
        }
    }
}
