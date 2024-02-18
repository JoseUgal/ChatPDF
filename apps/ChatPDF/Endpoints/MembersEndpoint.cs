using Codefastly.ChatPDF.Application.Services;
using Codefastly.ChatPDF.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Codefastly.ChatPDF.Endpoints;

[Route("api/members")]
public class MembersEndpoint(MemberService memberService) : Endpoint
{
    private readonly Member _member =
        Member.Create(Guid.NewGuid(), "support@codefastly.net", "Support", "Codefastly").Value;


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMemberById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(_member);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterMember(CancellationToken cancellationToken)
    {
        var result = await memberService.CreateMember(
            _member.Id,
            _member.Email,
            _member.FirstName,
            _member.LastName,
            cancellationToken
        );

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(GetMemberById),
            new { id = _member.Id },
            null
        );
    }
}