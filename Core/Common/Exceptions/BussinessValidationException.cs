namespace Core.Common.Exceptions;
public class BussinessValidationException : Exception
{
    public BussinessValidationException() : base()
    {
       
    }

    public BussinessValidationException(params string[] failure) : base("One or more validation failures have occurred.")
    {
        this.Failures = failure;
    }
    public BussinessValidationException(string failure) : base("One or more validation failures have occurred.")
    {
        
        this.Failures = new string[1] { failure };
    }
    
    public string[] Failures { get; }
}

