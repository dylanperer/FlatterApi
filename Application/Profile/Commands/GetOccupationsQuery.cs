using Application.Profile.Dto;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.PostgresSql;

namespace Application.Profile.Commands;

public struct GetOccupationsQuery : IRequest<Result<IEnumerable<OccupationDto>>>
{
    public class GetOccupationsQueryHandler : IRequestHandler<GetOccupationsQuery, Result<IEnumerable<OccupationDto>>>
    {
        private readonly PostgresDbContext _postgresDbContext;

        public GetOccupationsQueryHandler(PostgresDbContext postgresDbContext)
        {
            _postgresDbContext = postgresDbContext;
        }

        public async Task<Result<IEnumerable<OccupationDto>>> Handle(GetOccupationsQuery request,
            CancellationToken cancellationToken)
        {
            var occupations = await _postgresDbContext.Occupations.ToListAsync(cancellationToken: cancellationToken);
            return occupations.Select(c => new OccupationDto
            {
                OccupationId = c.OccupationId,
                Value = c.Value
            }).ToList();
        }
    }
}