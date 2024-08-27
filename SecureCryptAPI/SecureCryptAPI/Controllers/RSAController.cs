using Microsoft.AspNetCore.Mvc;
using SecureCryptAPI.UseCase;
using SecureCryptAPI.Models;


namespace SecureCryptAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RSAController : ControllerBase
{
    private readonly Encrypt rsa = new Encrypt();
    private readonly Decrypt decrypt = new Decrypt();

    [HttpPost]
    public ActionResult<string> PostMensage([FromBody] RSA request)
    {
        if (request.Message == null)
        {
            return BadRequest("Message is required");
        }
        rsa.GenerateKeys();
        List<int> encoded = rsa.Encoder(request.Message);
        return Ok(encoded);
    }

    [HttpPost]
    [Route("decrypt")]
    public ActionResult<string> DecryptMessage([FromBody] List<int> request)
    {
        if (request == null)
        {
            return BadRequest("Message is required");
        }
        string decoded = decrypt.Decoder(request);
        return Ok(decoded);
    }
}
