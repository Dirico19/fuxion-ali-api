namespace Fuxion.Ali.Application.Common
{
    public class Result<T>where T : class
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; } = 200;
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static Result<T> Ok(T data, string? message = null)
        {
            return new Result<T> { IsSuccess = true, Data = data, Message = message };
        }
        public static Result<T> Fail(int statusCode, string errorCode, string message)
        {
            return new Result<T> { IsSuccess = false, StatusCode = statusCode, ErrorCode = errorCode, Message = message };
        }
    }
}
