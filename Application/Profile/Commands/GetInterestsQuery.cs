using Application.Profile.Dto;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.PostgresSql;

namespace Application.Profile.Commands;

public struct GetInterestsQuery : IRequest<Result<IEnumerable<InterestDto>>>
{
    public class GetInterestsQueryHandler : IRequestHandler<GetInterestsQuery, Result<IEnumerable<InterestDto>>>
    {
        private readonly PostgresDbContext _postgresDbContext;

        public GetInterestsQueryHandler(PostgresDbContext postgresDbContext)
        {
            _postgresDbContext = postgresDbContext;
        }

        public async Task<Result<IEnumerable<InterestDto>>> Handle(GetInterestsQuery request,
            CancellationToken cancellationToken)
        {
            var interests = await _postgresDbContext.Interests.ToListAsync(cancellationToken: cancellationToken);
            return interests.Select(c => new InterestDto
            {
                InterestId = c.InterestId,
                Value = c.Value
            }).ToList();
        }
    }
}