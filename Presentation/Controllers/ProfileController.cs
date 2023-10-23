using Application.Profile.Commands;
using Application.Profile.Queries;
using Contracts;
using Contracts.Profile.Mappers;
using Contracts.Profile.Requests;
using Contracts.Profile.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Extensions;

namespace Presentation.Controllers;

// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{userId:int}",Name = nameof(GetById))]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        var query = new GetProfileByIdQuery(userId);

        var result = await _mediator.Send(query);

        return result.Resolve(ProfileResponseMapper.Map);
    }

    [ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create([FromBody] CreateProfileRequest request)
    {
        var command = new CreateProfileCommand(
            request.DisplayName,
            request.Description,
            request.GenderIdentityId,
            request.PrimaryImageUrl,
            request.ImageUrls,
            request.Age,
            request.PreferredGenderIdentityId,
            request.City,
            request.InterestIds,
            request.OccupationId,
            request.MaximumAcceptedDistance,
            request.PreferredMinimumAge,
            request.PreferredMaximumAge);

        var result = await _mediator.Send(command);
        return result.Resolve((c)=>Ok(c));
    }
    
    [ProducesResponseType(typeof(IEnumerable<GenderIdentitiesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [HttpGet( nameof(GetGenderIdentities))]
    public async Task<IActionResult> GetGenderIdentities([FromRoute] int userId)
    {
        var query = new GetGenderIdentitiesQuery();

        var result = await _mediator.Send(query);

        return result.Resolve(GenderIdentitiesResponseMapper.Map);
    }
}