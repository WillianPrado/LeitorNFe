using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using LeitorNFe.Domain.Domain;

namespace LeitorNFe.Web.Controllers
{
    [Route("api/NFe")]
    [ApiController]
    public class NFeController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadXml([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo não foi enviado.");
            }

            if (!file.FileName.EndsWith(".xml"))
            {
                return BadRequest("Por favor, envie um arquivo XML.");
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var infNFe = new InfNFe(memoryStream);
                    return Ok(infNFe);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro durante o processamento do arquivo: {ex.Message}");
            }
        }
    }
}
