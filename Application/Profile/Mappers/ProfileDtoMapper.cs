﻿using Application.Profile.Dto;
using Riok.Mapperly.Abstractions;

namespace Application.Profile.Mappers;

[Mapper]
public static partial class ProfileDtoMapper
{
    public static partial ProfileDto Map(PrototypeBackend.Entities.ProfileEntity result);
}
