using System.ComponentModel.DataAnnotations;

namespace PrototypeBackend.Entities;

public class ProfileInterestEntity
{
    [Key]
    public int ProfileInterestEntityId { get; set; }
    public int ProfileId { get; set; }
    public ProfileEntity Profile { get; set; }
    
    public int InterestId { get; set; }
    public InterestEntity Interest { get; set; }
}