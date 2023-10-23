using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototypeBackend.Entities;

public sealed class ProfileEntity : BaseEntity
{
    [Key] public int ProfileId { get; set; }

    public string DisplayName { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public int GenderIdentityId { get; set; }
    public GenderIdentityEntity GenderIdentity { get; set; }
    public string PrimaryImageUrl { get; set; } = null!;
    [Column(TypeName = "jsonb")]
    public IEnumerable<string> ImageUrls = new List<string>();
    public byte Age { get; set; }
    public int PreferredGenderIdentityId { get; set; }
    public GenderIdentityEntity PreferredGenderIdentity { get; set; }
    public string City { get; set; } = null!;
    public int MaximumAcceptedDistance { get; set; }
    public int PreferredMinimumAge  { get; set; }
    public int PreferredMaximumAge  { get; set; }
    // public IEnumerable<Interest> Interests { get; set; } = new List<Interest>();
    // [Column(TypeName = "jsonb")]
    public int? OccupationId { get; set; }
    public OccupationEntity? Occupation { get; set; }
    public UserEntity? User { get; set; }
}
