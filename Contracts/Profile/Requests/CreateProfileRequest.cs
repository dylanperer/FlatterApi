using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using PrototypeBackend.Entities;

namespace Contracts.Profile.Requests;

public struct CreateProfileRequest
{
    [Required] public int UserId { get; init; }
    [Required] public string DisplayName { get; init; }
    [Required] public string Description { get; init; }
    [Required] public Gender Gender { get; init; }
    [Required] public string PrimaryImageUrl { get; init; }
    public IEnumerable<string> ImageUrls { get; init; }
    [Required] public byte Age { get; init; }
    [Required] public string City { get; init; }
    [Required] public IEnumerable<Interest> Interests { get; set; }
    [Required] public Occupation Occupation { get; set; } 
    public int MaximumAcceptedDistance { get; init; }
    public Gender PreferredGender { get; init; }
    public int PreferredMinimumAge { get; init; }
    public int PreferredMaximumAge { get; init; }
}