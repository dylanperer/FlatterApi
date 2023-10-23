using PrototypeBackend.Entities;
using PrototypeBackend.Json;

namespace Contracts.Profile.Responses;

public struct ProfileResponse
{
    public string DisplayName  { get; set; }
    public string Description { get; set; }
    public Gender Gender  { get; set; }
    public string PrimaryImageUrl  { get; set; }
    public IEnumerable<string> ImageUrls  { get; set; }
    public byte Age  { get; set; }
    public Gender PreferredGender { get; set; }
    public string City { get; set; } 
    public IEnumerable<InterestResponse> Interests { get; set; }
    public OccupationResponse Occupation { get; set; }
    public int MaximumAcceptedDistance { get; set; } 
    public int PreferredMinimumAge { get; set; }
    public int PreferredMaximumAge { get; set; }
}