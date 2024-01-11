using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeitorNFe.Data;
using LeitorNFe.Domain.Domain;
using LeitorNFe.Domain.Interfaces;

public class UploadXmlModel : PageModel
{
    private readonly IInfNFeRepository _iInfNFeRepository;

    public UploadXmlModel(IInfNFeRepository iInfNFeRepository)
    {
        _iInfNFeRepository = iInfNFeRepository;
    }

    [BindProperty]
    public IFormFile File { get; set; }

    public string ErrorMessage { get; set; }
    public InfNFe Result { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (File == null || File.Length == 0)
        {
            ErrorMessage = "Arquivo não foi enviado.";
            return Page();
        }

        if (!File.FileName.EndsWith(".xml"))
        {
            ErrorMessage = "Por favor, envie um arquivo XML.";
            return Page();
        }

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                await File.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var infNFe = new InfNFe(memoryStream);
                Result = _iInfNFeRepository.Save(infNFe);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erro durante o processamento do arquivo: {ex.Message}";
        }

        return Page();
    }
}
