
namespace Core.Utilities.Results.DataResult

{

    public class DataResult<T> : Result.Result.Result, IDataResult<T>
    {
        public T Data { get ; set ; }

        public DataResult(bool isSucess, string message, T data) : base(isSucess, message)
        {
            Data = data;
        }

        public DataResult(bool isSuccess, T data) : base(isSuccess)
        {
            Data = data;
        }

    }
}
