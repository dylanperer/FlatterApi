using System.ComponentModel.DataAnnotations;
using Application.External.Interfaces.Authentication;
using LanguageExt.Common;
using MediatR;
using Persistence.PostgresSql;
namespace Application.Profile.Commands;
using PrototypeBackend.Entities;

public struct CreateProfileCommand : IRequest<Result<int>>
{
    private readonly string _displayName;
    private readonly string _description;
    private readonly int _genderIdentityId;
    private readonly string _primaryImageUrl;
    private readonly IEnumerable<string> _imageUrls;
    private readonly byte _age;
    private readonly int _preferredGenderIdentityId;
    private readonly string _city;
    private readonly IEnumerable<int> _interestsIds;
    private readonly int _occupationId;
    private readonly int? _maximumAcceptedDistance;
    private readonly int? _preferredMinimumAge;
    private readonly int? _preferredMaximumAge;

    public CreateProfileCommand(string displayName, string description, int genderIdentityId,
        string primaryImageUrl,
        IEnumerable<string> imageUrls, byte age, int preferredGenderIdentityId, string city, IEnumerable<int> interestsIds,
        int occupationId,
        int maximumAcceptedDistance,
        int preferredMinimumAge, int preferredMaximumAge)
    {
        _displayName = displayName;
        _description = description;
        _genderIdentityId = genderIdentityId;
        _primaryImageUrl = primaryImageUrl;
        _imageUrls = imageUrls;
        _age = age;
        _city = city;
        _interestsIds = interestsIds;
        _occupationId = occupationId;
        _maximumAcceptedDistance = maximumAcceptedDistance;
        _preferredGenderIdentityId = preferredGenderIdentityId;
        _preferredMinimumAge = preferredMinimumAge;
        _preferredMaximumAge = preferredMaximumAge;
    }

    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Result<int>>
    {
        private readonly PostgresDbContext _postgresDbContext;
        private readonly IUserProvider _userProvider;

        public CreateProfileCommandHandler(PostgresDbContext postgresDbContext, IUserProvider userProvider)
        {
            _postgresDbContext = postgresDbContext;
            _userProvider = userProvider;
        }

        public async Task<Result<int>> Handle(CreateProfileCommand request,
            CancellationToken cancellationToken)
        {
            _postgresDbContext.Profiles.Add(new ProfileEntity
            {
                ProfileId = _userProvider.UserId,
                DisplayName = request._displayName,
                GenderIdentityId = request._genderIdentityId,
                Description = request._description,
                PrimaryImageUrl = request._primaryImageUrl,
                ImageUrls = request._imageUrls,
                Age = request._age,
                City = request._city,
                PreferredGenderIdentityId = request._preferredGenderIdentityId,
                PreferredMinimumAge = request._preferredMinimumAge ?? 18,
                PreferredMaximumAge = request._preferredMaximumAge ?? 99,
                MaximumAcceptedDistance = request._maximumAcceptedDistance ?? 99,
                OccupationId = request._occupationId,
            });
            
            foreach (var interestId in request._interestsIds)
            {
                _postgresDbContext.ProfileInterests.Add(new ProfileInterestEntity
                {
                    ProfileId = _userProvider.UserId,
                    InterestId = interestId
                });
            }
            
            try
            {
                return await _postgresDbContext.SaveChangesAsync(cancellationToken);
            }
            catch 
            {
                return new ValidationException(ExceptionsConstants.ProfileCreationFailed).ToResult<int>();
            }
        }
    }
}