using PrototypeBackend.Entities;
using PrototypeBackend.Json;

namespace Application.Profile.Dto;

public struct ProfileDto
{
    public string DisplayName;
    public string Description;
    public Gender Gender { get; set; }
    public string PrimaryImageUrl;
    public IEnumerable<string> ImageUrls;
    public byte Age;
    public Gender PreferredGender;
    public string City;
    public IEnumerable<Interest> Interests { get; set; } 
    public int OccupationId { get; set; } 
    public Occupation? Occupation { get; set; } 
    public int MaximumAcceptedDistance;
    public int PreferredMinimumAge;
    public int PreferredMaximumAge;
}