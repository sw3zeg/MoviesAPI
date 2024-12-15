namespace Movies.Domain.Entities;

public record Result
{
    public String Message { get; set; }

    public Result(String message)
    {
        Message = message;
    }
}