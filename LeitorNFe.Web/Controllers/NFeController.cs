using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using LeitorNFe.Domain.Domain;
using LeitorNFe.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LeitorNFe.Domain.Interfaces;

namespace LeitorNFe.Web.Controllers
{
    [Route("api/NFe")]
    [ApiController]
    public class NFeController : ControllerBase
    {

        protected readonly IInfNFeRepository _iInfNFeRepository;
        public NFeController(IInfNFeRepository iInfNFeRepository)
        {
            _iInfNFeRepository = iInfNFeRepository;
        }
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
                    //return Ok(infNFe);
                    var infNFeSaved = _iInfNFeRepository.Save(infNFe);
                    return Ok(infNFeSaved);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro durante o processamento do arquivo: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetByID([FromQuery] string ID)
        {
            try
            {
                var  InfNFe = _iInfNFeRepository.GetById(ID);
                return Ok(InfNFe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro durante o processamento do arquivo: {ex.Message}");
            }
        }
    }
}
