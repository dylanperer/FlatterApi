using System.ComponentModel.DataAnnotations;
using Application.External.Interfaces.Authentication;
using LanguageExt.Common;
using MediatR;
using Persistence.PostgresSql;
using PrototypeBackend.Json;

namespace Application.Profile.Commands;

using PrototypeBackend.Entities;

public struct CreateProfileCommand : IRequest<Result<int>>
{
    private readonly string _displayName;
    private readonly string _description;
    private readonly GenderJson _gender;
    private readonly string _primaryImageUrl;
    private readonly IEnumerable<string> _imageUrls;
    private readonly byte _age;
    private readonly GenderJson _preferredGender;
    private readonly string _city;
    private readonly IEnumerable<InterestJson> _interests;
    private readonly OccupationJson _occupation;
    private readonly int? _maximumAcceptedDistance;
    private readonly int? _preferredMinimumAge;
    private readonly int? _preferredMaximumAge;

    public CreateProfileCommand(string displayName, string description, GenderJson gender,
        string primaryImageUrl,
        IEnumerable<string> imageUrls, byte age, GenderJson preferredGender, string city, IEnumerable<InterestJson> interests,
        OccupationJson occupation,
        int maximumAcceptedDistance,
        int preferredMinimumAge, int preferredMaximumAge)
    {
        _displayName = displayName;
        _description = description;
        _gender = gender;
        _primaryImageUrl = primaryImageUrl;
        _imageUrls = imageUrls;
        _age = age;
        _city = city;
        _interests = interests;
        _occupation = occupation;
        _maximumAcceptedDistance = maximumAcceptedDistance;
        _preferredGender = preferredGender;
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
                Gender = request._gender,
                Description = request._description,
                PrimaryImageUrl = request._primaryImageUrl,
                ImageUrls = request._imageUrls,
                Age = request._age,
                City = request._city,
                PrefferedGender = request._preferredGender,
                PreferredMinimumAge = request._preferredMinimumAge ?? 18,
                PreferredMaximumAge = request._preferredMaximumAge ?? 99,
                MaximumAcceptedDistance = request._maximumAcceptedDistance ?? 99,
                Occupation = request._occupation,
                Interests = request._interests
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