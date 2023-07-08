using System.ComponentModel.DataAnnotations;
namespace TestRelationship.Dtos;

public class UserUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(120)]
    public string? LastName { get; set; }
    [Range(1, 100)]
    public int? Age { get; set; }
    [EmailAddress]
    [MaxLength(120)]
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }
    public bool? IsDeveloper { get; set; }
}