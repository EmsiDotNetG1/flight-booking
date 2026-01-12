namespace Emsi.FlightBooking.Exceptions;

public class FunctionalException : Exception
{
    public ExceptionTypeEnum Type { private set; get; }
    
    public FunctionalException(ExceptionTypeEnum type, string message) : base(message)
    {
        Type = type;
    }
}

public enum ExceptionTypeEnum
{
    NotFound,
    BadInput,
    ServerError,
    DependencyError
}