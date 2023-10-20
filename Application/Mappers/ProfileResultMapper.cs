using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class ProfileResultMapper
{
    public partial ProfileDto Map(PrototypeBackend.Entities.Profile result);
}

