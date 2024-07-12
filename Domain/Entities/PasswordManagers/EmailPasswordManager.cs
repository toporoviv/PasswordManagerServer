namespace Domain.Entities.Records;
public class EmailPasswordManager
{
    public int Id { get; init; }
    public required string Password { get; init; }
    public required DateTime Date { get; init; }
    public required string Email { get; init; }
}
