// using Application.Dtos;
// using Application.External.Interfaces.Authentication;
// using Application.Mappers;
// using LanguageExt.Common;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence.PostgresSql;
//
// namespace Application.Profile.Queries;
//
// public struct GetGenderIdentitiesQuery : IRequest<Result<ProfileDto>>
// {
//     public class GetGenderIdentitiesQueryHandler : IRequestHandler<GetProfileByIdQuery, Result<ProfileDto>>
//     {
//         private readonly PostgresDbContext _postgresDbContext;
//         private readonly IUserProvider _userProvider;
//
//         public GetGenderIdentitiesQueryHandler(PostgresDbContext postgresDbContext, IUserProvider userProvider)
//         {
//             _postgresDbContext = postgresDbContext;
//             _userProvider = userProvider;
//         }
//
//         public async Task<Result<ProfileDto>> Handle(GetProfileByIdQuery request,
//             CancellationToken cancellationToken)
//         {
//             var profile =
//                 await _postgresDbContext.Profiles.FirstOrDefaultAsync(c => c.ProfileId == request._userId,
//                     cancellationToken: cancellationToken);
//
//             if (profile == null)
//             {
//                 return new KeyNotFoundException().ToResult<ProfileDto>();
//             }
//             
//             return new ProfileResultMapper().Map(profile);
//         }
//     }
// }