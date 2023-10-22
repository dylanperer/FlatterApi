using System.ComponentModel.DataAnnotations;

namespace PrototypeBackend.Json;

public struct GenderJson
{
    [Range(1, int.MaxValue)]
    public int GenderIdentityId { get; set; }

    public string Value  { get; set; }
}