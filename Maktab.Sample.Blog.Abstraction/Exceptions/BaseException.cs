namespace Maktab.Sample.Blog.Abstraction.Exceptions;

public class BaseException : Exception
{
    public BaseException(string message) : base(message)
    {

    }

    public string Code { get; set; }
}