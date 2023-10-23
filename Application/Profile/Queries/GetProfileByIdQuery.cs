﻿using Application.External.Interfaces.Authentication;
using Application.Profile.Dto;
using Application.Profile.Mappers;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.PostgresSql;
using PrototypeBackend.Entities;

namespace Application.Profile.Queries;

public struct GetProfileByIdQuery : IRequest<Result<ProfileDto>>
{
    private readonly int _userId;

    public GetProfileByIdQuery(int userId)
    {
        _userId = userId;
    }

    public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, Result<ProfileDto>>
    {
        private readonly PostgresDbContext _postgresDbContext;

        public GetProfileByIdQueryHandler(PostgresDbContext postgresDbContext)
        {
            _postgresDbContext = postgresDbContext;
        }

        public async Task<Result<ProfileDto>> Handle(GetProfileByIdQuery request,
            CancellationToken cancellationToken)
        {
            var profile =
                await _postgresDbContext.Profiles
                    .Include(c => c.GenderIdentity)
                    .Include(c=>c.PreferredGenderIdentity)
                    .Include(c => c.Occupation)
                    .Include(c => c.ProfileInterest)
                    .ThenInclude(c=>c.Interest)
                    .FirstOrDefaultAsync(c => c.ProfileId == request._userId,
                        cancellationToken: cancellationToken);

            return profile == null ? new KeyNotFoundException().ToResult<ProfileDto>() : ProfileDtoMapper.Map(profile);
        }
    }
}