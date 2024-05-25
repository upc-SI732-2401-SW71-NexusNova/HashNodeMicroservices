namespace HashNode.API.Shared.Domain.Services.Communication

{
    public class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; protected set; }

        public BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
