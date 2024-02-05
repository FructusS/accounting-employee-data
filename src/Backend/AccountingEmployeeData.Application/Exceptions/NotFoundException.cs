namespace AccountingEmployeeData.Application.Exceptions;

public class NotFoundException : Exception
{

    public NotFoundException()
    {
        
    }

    public NotFoundException(string error) : base(error)
    {
        
    }

    public NotFoundException(Exception? exception, string? error) : base(error,exception)
    {
        
    }
    
}