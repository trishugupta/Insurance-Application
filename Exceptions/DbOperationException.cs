namespace AuthApi.Exceptions
{
    public class DbOperationException : Exception
    {
        public DbOperationException()
        {
        }

        public DbOperationException(string message) 
            : base(message)
        {
        }
    }
}
