namespace RiraTask.Domain.Models;

public class User : ModelBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Required] public string NationalId { get; set; } = null!;

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime BirthDay { get; set; }
}