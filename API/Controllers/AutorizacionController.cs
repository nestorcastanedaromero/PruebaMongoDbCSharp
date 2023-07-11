using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AutorizacionController : ControllerBase
    {
        /// <summary>
        /// Obtiene el token para acceder a los api de polizas
        /// </summary>
        /// <returns>Token</returns>
        /// GET: api/Autorizacion/Token
        [HttpGet("Token")]
        public IActionResult ObtenerToken()
        {
            // Aquí deberíamos verificar las credenciales del usuario
            // y si las credenciales son válidas, generar el token JWT
            var token = GenerarJwtToken();

            return Ok(new { token });
        }

        private string GenerarJwtToken()
        {
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Esta clave secreta debería estar alojada en en vault"));
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: new Claim[] { },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credenciales);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}