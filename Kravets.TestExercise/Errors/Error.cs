namespace Kravets.TestExercise.Errors;

public class Error
{
    protected Error(string message)
    {
        Message = message;
    }

    public string Message { get; }
}