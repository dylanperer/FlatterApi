using Application.Dtos;
using Contracts.Profile.Responses;
using Riok.Mapperly.Abstractions;

namespace Contracts.Profile.Mappers;

[Mapper]
public static partial class ProfileResponseMapper
{
    public static partial ProfileResponse Map(ProfileDto dto);
}