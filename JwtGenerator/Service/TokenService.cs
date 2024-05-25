using JwtGenerator.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JwtGenerator.Service
{
    public class TokenService
    {
        public ResponseDTO CreateToken(CreateTokenDTO dto)
        {
            var response = new ResponseDTO();
            #region Validations

            if (String.IsNullOrWhiteSpace(dto.Key))
                response.Data += "Key is requerid. ";

            if (dto.TimeIsSeconds <= 0 || dto.TimeIsSeconds > 86400)
                response.Data += "Time is requerid. (between 1 and 86400). ";

            if (String.IsNullOrWhiteSpace(dto.Audience))
                response.Data += "Audience is requerid. ";

            if (String.IsNullOrWhiteSpace(dto.Issuer))
                response.Data += "Issuer is requerid. ";

            if (!String.IsNullOrWhiteSpace(response.Data))
            {
                response.Success = false;
                return response;
            }
            #endregion

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(dto.Key);

                List<Claim> claimsList = new List<Claim>();
                if (!String.IsNullOrWhiteSpace(dto.Name))
                    claimsList.Add(new Claim(ClaimTypes.Name, dto.Name));

                if (!String.IsNullOrWhiteSpace(dto.Email))
                    claimsList.Add(new Claim(ClaimTypes.Name, dto.Email));

                if (dto.Claims != null && dto.Claims.Any())
                {
                    foreach (var claim in dto.Claims)
                    {
                        if (!String.IsNullOrWhiteSpace(claim.Key) && !String.IsNullOrWhiteSpace(claim.Value))
                            claimsList.Add(new Claim(claim.Key, claim.Value));
                    }
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claimsList.ToArray()),
                    Expires = DateTime.UtcNow.AddSeconds(dto.TimeIsSeconds),
                    Issuer = dto.Issuer,
                    Audience = dto.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Data = tokenHandler.WriteToken(token);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = "The JWT Token could not be generared, an exception was thrown: " + ex.Message;
            }
            return response;
        }
    }
}
