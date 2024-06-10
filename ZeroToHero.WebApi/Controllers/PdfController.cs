using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZeroToHero.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PdfController(IResumeService service, 
                           IHttpClientFactory clientFactory) : ControllerBase
{
    private readonly IResumeService _service = service;
    private readonly IHttpClientFactory _clientFactory = clientFactory;

    [HttpPost("resume")]
    public async Task<IActionResult> CreateAsync([FromForm]AddResumeDto dto)
    {
        await _service.CreateAsync(dto);

        var client = _clientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(dto);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://localhost:7203/api/Files/save", content);

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }
        else
        {
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
    [HttpPost("file")]
    public async Task<IActionResult> SaveFileAsync(IFormFile file)
    {
        var client = _clientFactory.CreateClient();
        var json = "";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://localhost:7203/api/Files/upload", content);

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }
        else
        {
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
        
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