using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Utilidades
{
    public static class Token
    {
        public static void ValidarToken(this IServiceCollection servicios)
        {
            servicios.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "issuer", 
                        ValidAudience = "audience", 
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Esta clave secreta debería estar alojada en en vault"))
                    };
                });
        }
    }
}
