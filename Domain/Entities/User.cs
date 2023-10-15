using System.ComponentModel.DataAnnotations;
namespace PrototypeBackend.Entities;

public class User : BaseEntity
{
    [Key]
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public virtual Profile? Profile { get; set; }
}