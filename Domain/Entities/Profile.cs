using System.ComponentModel.DataAnnotations;
namespace PrototypeBackend.Entities;

public class Profile: BaseEntity
{
    [Key]
    public int ProfileId { get; set; }
    
    public string DisplayName { get; set; } = null!;
    public string? Description { get; set; }
    public Gender Gender { get; set; }

    public string PrimaryImageUrl { get; set; } = null!;
    public IEnumerable<string> ImageUrls = new List<string>(); 
    public byte Age { get; set; }
    public string City { get; set; } = null!;
    public virtual IEnumerable<Interest> Interests { get; set; } = null!;
    public virtual Occupation Occupation { get; set; } = null!;

    public int MaximumAcceptedDistance { get; set; }
    public Gender PreferredGender;
    public int PreferredMinimumAge;
    public int PreferredMaximumAge;
    
    public virtual User? User { get; set; }
}

public enum Gender
{
    Female = 0,
    Male = 1,
    BiSexual = 2
}

