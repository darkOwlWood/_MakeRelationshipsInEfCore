using TestRelationship.Utils.Enums;
namespace TestRelationship.Dtos;

public class MessageBaseDto
{
    public int MessageId { get; set; }
    public string MessageText { get; set; }
    public MessageState MessageState { get; set; }
    public UserBaseDto? Sender { get; set; }
    public UserBaseDto? Reciver { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}