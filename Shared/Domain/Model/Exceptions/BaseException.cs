namespace HashNode.API.Shared.Domain.Model.Exceptions
{
    public abstract class BaseException<T> : Exception
    {
        public T Details { get; private set; }

        public BaseException(string message, T details) : base(message)
        {
            Details = details;
        }
    }
}
