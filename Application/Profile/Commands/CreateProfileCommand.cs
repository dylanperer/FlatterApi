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
    private readonly GenderIdentityEntity _genderIdentity;
    private readonly string _primaryImageUrl;
    private readonly IEnumerable<string> _imageUrls;
    private readonly byte _age;
    private readonly GenderIdentityEntity _preferredGenderIdentity;
    private readonly string _city;
    private readonly IEnumerable<InterestEntity> _interests;
    private readonly OccupationEntity? _occupation;
    private readonly int? _maximumAcceptedDistance;
    private readonly int? _preferredMinimumAge;
    private readonly int? _preferredMaximumAge;

    public CreateProfileCommand(string displayName, string description, GenderIdentityEntity genderIdentity,
        string primaryImageUrl,
        IEnumerable<string> imageUrls, byte age, GenderIdentityEntity preferredGenderIdentity, string city, IEnumerable<InterestEntity> interests,
        OccupationEntity occupation,
        int maximumAcceptedDistance,
        int preferredMinimumAge, int preferredMaximumAge)
    {
        _displayName = displayName;
        _description = description;
        _genderIdentity = genderIdentity;
        _primaryImageUrl = primaryImageUrl;
        _imageUrls = imageUrls;
        _age = age;
        _city = city;
        _interests = interests;
        _occupation = occupation;
        _maximumAcceptedDistance = maximumAcceptedDistance;
        _preferredGenderIdentity = preferredGenderIdentity;
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
                GenderIdentityId = request._genderIdentity.GenderIdentityId,
                Description = request._description,
                PrimaryImageUrl = request._primaryImageUrl,
                ImageUrls = request._imageUrls,
                Age = request._age,
                City = request._city,
                PreferredGenderIdentityId = request._preferredGenderIdentity.GenderIdentityId,
                PreferredMinimumAge = request._preferredMinimumAge ?? 18,
                PreferredMaximumAge = request._preferredMaximumAge ?? 99,
                MaximumAcceptedDistance = request._maximumAcceptedDistance ?? 99,
                OccupationId = request._occupation.OccupationId,
                // In = request._interests
            });

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