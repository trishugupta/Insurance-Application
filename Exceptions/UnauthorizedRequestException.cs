namespace AuthApi.Exceptions
{
    public class UnauthorizedRequestException : Exception
    {
        public UnauthorizedRequestException()
        {
        }

        public UnauthorizedRequestException(string message) : base(message)
        {
        }
    }
}
