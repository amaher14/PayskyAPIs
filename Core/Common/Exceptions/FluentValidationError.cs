
namespace Core.Common.Exceptions;
public class FluentValidationError
{
    public record Error(string Code, string Description);
}

