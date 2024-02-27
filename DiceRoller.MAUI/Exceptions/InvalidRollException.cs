namespace DiceRoller.MAUI.Exceptions;

public class InvalidRollException : Exception
{
    public InvalidRollException()
    {
    }

    public InvalidRollException(string message)
        : base(message)
    {
    }

    public InvalidRollException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
