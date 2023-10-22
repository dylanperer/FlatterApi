using Contracts.Profile.Responses;
using PrototypeBackend.Entities;
using Riok.Mapperly.Abstractions;

namespace Contracts.Profile.Mappers;

[Mapper]
public static partial class OccupationResponseMapper
{
    public static partial OccupationResponse Map(OccupationEntity occupationEntity);
}