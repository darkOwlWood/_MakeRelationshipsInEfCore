namespace TestRelationship.Dtos;

public class UserBaseDto
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public bool? IsDeveloper { get; set; }
    public ICollection<MessageBaseDto>? MessageList { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}