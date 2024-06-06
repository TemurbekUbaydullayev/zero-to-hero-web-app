using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace ZeroToHero.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    [HttpGet("generate")]
    public IActionResult GeneratePdf()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();
            document.Add(new Paragraph("Salom, bu PDF faylga yozilgan matn!"));
            document.Close();
            writer.Close();
            byte[] byteArray = ms.ToArray();
            var result =  File(byteArray, "application/pdf", "example.pdf");

            return result;
        }
    }
}