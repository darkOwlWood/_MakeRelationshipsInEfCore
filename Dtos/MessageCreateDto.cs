using System.ComponentModel.DataAnnotations;
using TestRelationship.Utils.Enums;
namespace TestRelationship.Dtos;

public class MessageCreateDto
{
    [Required]
    [MaxLength(500)]
    public string MessageText { get; set; }
    [Required]
    // [EnumDataType(typeof(MessageState))]
    public MessageState MessageState { get; set; }
    [Required]
    public int SenderId { get; set; }
    [Required]
    public int ReciverId { get; set; }
}