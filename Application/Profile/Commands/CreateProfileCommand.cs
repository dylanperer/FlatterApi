using System.ComponentModel.DataAnnotations;
using Application.Dtos;
using Application.External.Interfaces.Authentication;
using Application.Mappers;
using LanguageExt.Common;
using MediatR;
using Persistence.PostgresSql;

namespace Application.Profile.Commands;

using PrototypeBackend.Entities;

public struct CreateProfileCommand : IRequest<Result<ProfileDto>>
{
    private readonly string _displayName;
    private readonly string _description;
    private readonly Gender _gender;
    private readonly string _primaryImageUrl;
    private readonly IEnumerable<string> _imageUrls;
    private readonly byte _age;

    private readonly string _city;

    private readonly IEnumerable<Interest> _interests;
    private readonly  Occupation _occupation;
    private readonly int? _maximumAcceptedDistance;
    private readonly Gender? _preferredGender;
    private readonly int? _preferredMinimumAge;
    private readonly int? _preferredMaximumAge;

    public CreateProfileCommand(string displayName, string description, Gender gender,
        string primaryImageUrl,
        IEnumerable<string> imageUrls, byte age, string city,  IEnumerable<Interest> interests, Occupation occupation, int maximumAcceptedDistance, Gender preferredGender,
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

    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Result<ProfileDto>>
    {
        private readonly PostgresDbContext _postgresDbContext;
        private readonly IUserProvider _userProvider;

        public CreateProfileCommandHandler(PostgresDbContext postgresDbContext, IUserProvider userProvider)
        {
            _postgresDbContext = postgresDbContext;
            _userProvider = userProvider;
        }

        public async Task<Result<ProfileDto>> Handle(CreateProfileCommand request,
            CancellationToken cancellationToken)
        {
            var profile = _postgresDbContext.Profiles.Add(new Profile
            {
                ProfileId = _userProvider.UserId,
                DisplayName = request._displayName,
                Description = request._description,
                PrimaryImageUrl = request._primaryImageUrl,
                ImageUrls = request._imageUrls,
                Gender = request._gender,
                Age = request._age,
                City = request._city,
                //@todo create auto pref gender assigner
                PreferredGender = request._preferredGender ?? Gender.BiSexual,
                PreferredMinimumAge = request._preferredMinimumAge ?? 18,
                PreferredMaximumAge = request._preferredMaximumAge ?? 99,
                MaximumAcceptedDistance = request._maximumAcceptedDistance ?? 99,
                Occupation = request._occupation,
                Interests = request._interests
            }).Entity;

            try
            {
                await _postgresDbContext.SaveChangesAsync(cancellationToken);
            }
            catch 
            {
                return new ValidationException(ExceptionsConstants.ProfileCreationFailed).ToResult<ProfileDto>();
            }

            return new ProfileResultMapper().Map(profile);
        }
    }
}