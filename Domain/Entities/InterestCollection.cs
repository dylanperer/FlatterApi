namespace PrototypeBackend.Entities;

public class InterestCollection: BaseEntity
{
    public int InterestCollectionId { get; set; } 
    public Interest Interests { get; set; }
}