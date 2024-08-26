using Microsoft.AspNetCore.Mvc;
using SecureCryptAPI.UseCase;
using SecureCryptAPI.Models;
using System.Numerics;

namespace SecureCryptAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RSAController : ControllerBase
{
    private readonly GenereteRSA rsa = new GenereteRSA();

    [HttpPost]
    public ActionResult<string> PostMensage([FromBody] RSA request)
    {
        if (request == null) {

            return BadRequest("Invalid request");
        }


        BigInteger e = BigInteger.Parse(request.E);
        BigInteger n = BigInteger.Parse(request.N);
        BigInteger plaintext = new BigInteger(System.Text.Encoding.UTF8.GetBytes(request.Mensage));

        BigInteger encriptedMensage = rsa.Encrypt(plaintext, e, n);
        return Ok(encriptedMensage.ToString());
    }
}
