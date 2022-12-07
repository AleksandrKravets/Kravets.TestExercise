namespace Kravets.TestExercise.Errors;

public class ValidationError : Error
{
    public ValidationError(string message) : base(message) { }
}