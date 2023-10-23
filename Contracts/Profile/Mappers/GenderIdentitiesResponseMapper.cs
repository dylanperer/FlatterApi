using Application.Profile.Dto;
using Contracts.Profile.Responses;
using Riok.Mapperly.Abstractions;

namespace Contracts.Profile.Mappers;

[Mapper]
public static partial class GenderIdentityResponseMapper
{
    public static partial GenderIdentitiesResponse Map(GenderDto occupationEntity);
}

[Mapper]
public static partial class GenderIdentitiesResponseMapper
{
    public static partial IEnumerable<GenderIdentitiesResponse> Map(IEnumerable<GenderDto> occupationEntity);
}