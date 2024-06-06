using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PdfController(IResumeService service) : ControllerBase
{
    private readonly IResumeService _service = service;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm]AddResumeDto dto)
    {
        await _service.CreateAsync(dto);

        return Ok();
    }
    [HttpGet("generate")]
    public async Task<IActionResult> GeneratePdf(string email)
    {
        var result = await _service.GetCVAsync(email);
        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();
            document.Add(new Paragraph(result.data));
            document.Close();
            writer.Close();
            byte[] byteArray = ms.ToArray();
            return File(byteArray, "application/pdf", result.filename);
        }
    }
}