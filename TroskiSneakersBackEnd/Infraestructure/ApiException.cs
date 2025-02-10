namespace TroskiSneakersBackEnd.Infraestructure
{
    public class ApiException : Exception
    {
        public ApiException() { }
        public ApiException(object v, string message) : base(message) { }
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
