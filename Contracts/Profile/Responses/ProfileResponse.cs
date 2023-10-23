using Application.Profile.Dto;
using PrototypeBackend.Entities;

namespace Contracts.Profile.Responses;

public struct ProfileResponse
{
    public string DisplayName;
    public string Description;
    public GenderDto GenderIdentity { get; set; }
    public string PrimaryImageUrl;
    public IEnumerable<string> ImageUrls;
    public byte Age;
    public GenderDto PreferredGenderIdentity;
    public string City;
    public IEnumerable<ProfileInterestDto> ProfileInterest { get; set; } 
    public OccupationDto? Occupation { get; set; } 
    public int MaximumAcceptedDistance;
    public int PreferredMinimumAge;
    public int PreferredMaximumAge;
}