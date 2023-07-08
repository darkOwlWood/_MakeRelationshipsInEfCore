using System.ComponentModel.DataAnnotations;
namespace TestRelationship.Dtos;

public class UserCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(120)]
    public string LastName { get; set; }
    [Required]
    [Range(1,100)]
    public int Age { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public bool? IsDeveloper { get; set; }
}