using Application.Profile.Dto;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.PostgresSql;

namespace Application.Profile.Commands;

public struct GetGendersQuery : IRequest<Result<IEnumerable<GenderDto>>>
{
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, Result<IEnumerable<GenderDto>>>
    {
        private readonly PostgresDbContext _postgresDbContext;

        public GetGendersQueryHandler(PostgresDbContext postgresDbContext)
        {
            _postgresDbContext = postgresDbContext;
        }

        public async Task<Result<IEnumerable<GenderDto>>> Handle(GetGendersQuery request,
            CancellationToken cancellationToken)
        {
            var genders = await _postgresDbContext.Genders.ToListAsync(cancellationToken: cancellationToken);
            return genders.Select(c => new GenderDto
            {
                GenderIdentityId = c.GenderIdentityId,
                Value = c.Value
            }).ToList();
        }
    }
}