using System.ComponentModel.DataAnnotations;
namespace PrototypeBackend.Entities;

public class Profile: BaseEntity
{
    [Key]
    public int ProfileId { get; set; }
    
    public string DisplayName { get; set; } = null!;
    public string? Description { get; set; }
    public int GenderIdentityId { get; set; }
    public virtual GenderIdentity? GenderIdentity { get; set; }
    public string PrimaryImageUrl { get; set; } = null!;
    public IEnumerable<string> ImageUrls = new List<string>(); 
    public byte Age { get; set; }
    public string City { get; set; } = null!;
    // public IEnumerable<int> InterestsIds { get; set; } = null!;
    public int InterestCollectionId { get; set; }
    public virtual InterestCollection? InterestCollection { get; set; }
    public int OccupationId { get; set; }
    public virtual Occupation? Occupation { get; set; }
    public int MaximumAcceptedDistance { get; set; }
    public int? PreferredGenderIdentityId { get; set; }
    public virtual GenderIdentity? PreferredGenderIdentity { get; set; }
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

