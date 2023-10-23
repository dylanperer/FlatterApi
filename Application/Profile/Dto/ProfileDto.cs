namespace Application.Profile.Dto;

public struct ProfileDto
{
    public string DisplayName;
    public string Description;
    public GenderDto Gender { get; set; }
    public string PrimaryImageUrl;
    public IEnumerable<string> ImageUrls;
    public byte Age;
    public GenderDto PreferredGender;
    public string City;
    public IEnumerable<InterestDto> Interests { get; set; } 
    public int OccupationId { get; set; } 
    public OccupationDto? Occupation { get; set; } 
    public int MaximumAcceptedDistance;
    public int PreferredMinimumAge;
    public int PreferredMaximumAge;
}