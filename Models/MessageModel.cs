using TestRelationship.Utils.Enums;
namespace TestRelationship.Models;

public class MessageModel
{
    public int MessageModelId { get; set; }
    public string MessageText { get; set; }
    public MessageState MessageState { get; set; }
    public int SenderId { get; set; }
    public UserModel Sender { get; set; }
    public int ReciverId { get; set; }
    public UserModel Reciver { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}