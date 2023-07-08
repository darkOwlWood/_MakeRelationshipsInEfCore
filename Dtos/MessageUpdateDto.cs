using System.ComponentModel.DataAnnotations;
using TestRelationship.Utils.Enums;
namespace TestRelationship.Dtos;

public class MessageUpdateDto
{
    [MaxLength(500)]
    public string? MessageText { get; set; }
    public MessageState? MessageState { get; set; }
}