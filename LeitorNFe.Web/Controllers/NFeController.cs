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

                    using (var reader = new StreamReader(memoryStream))
                    {
                        string xmlContent = await reader.ReadToEndAsync();
                        Product product = new Product();
                        var products = product.ParseXml(xmlContent);
                        // Aqui está o conteúdo do arquivo XML em forma de string (xmlContent)
                        // Você pode processar ou manipular essa string conforme necessário

                        return Ok(products);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro durante o processamento do arquivo: {ex.Message}");
            }
        }
    }
}
