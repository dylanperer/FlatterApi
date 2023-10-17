using Application.Profile.Commands;
using Contracts.Profile.Mappers;
using Contracts.Profile.Requests;
using Contracts.Profile.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Extensions;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create([FromBody] CreateProfileRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new CreateProfileCommand(
            request.DisplayName, 
            request.Description,
            request.Gender,
            request.PrimaryImageUrl,
            request.ImageUrls,
            request.Age,
            request.City,
            request.Interests,
            request.Occupation,
            request.MaximumAcceptedDistance,
            request.PreferredGender, 
            request.PreferredMinimumAge,
            request.PreferredMaximumAge);

        var result = await _mediator.Send(command);

        return result.Resolve(ProfileResponseMapper.Map);
    }
}