using PrototypeBackend.Entities;

namespace Application.Profile.Dto;

public struct ProfileDto
{
    public string DisplayName;
    public string? Description;
    public int GenderIdentityId;
    public GenderEntity? GenderIdentity { get; set; }
    public string PrimaryImageUrl;
    public IEnumerable<string> ImageUrls;
    public byte Age;
    public string City;
    public IEnumerable<InterestDto> Interests { get; set; } 
    public int OccupationId { get; set; } 
    public OccupationDto? Occupation { get; set; } 
    public int MaximumAcceptedDistance;
    public int? PreferredGenderIdentityId;
    public GenderEntity? PreferredGenderIdentity;
    public int PreferredMinimumAge;
    public int PreferredMaximumAge;
}