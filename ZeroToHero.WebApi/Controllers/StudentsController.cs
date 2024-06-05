using Microsoft.AspNetCore.Mvc;
using ZeroToHero.Application.Common.DTOs.StudentDtos;
using ZeroToHero.Application.Common.Utils;
using ZeroToHero.Application.Interfaces;

namespace ZeroToHero.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IStudentService service) : ControllerBase
{
    private readonly IStudentService _service = service;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm]AddStudentDto dto)
    {
        await _service.RegisterAsync(dto);
        return Ok();
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetAllAsync([FromQuery]PaginationParams @params)
        => Ok(await _service.GetAllAsync(@params));
}