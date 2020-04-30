﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using restapi_base.Helpers.Interfaces;

namespace restapi_base.Helpers.Implementations
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private byte[] secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            secretBytes = secret;
        }

        // This method generates and returns a JWT token for a user.
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Firstname", user.FirstName),
                new Claim("Lastname", user.LastName)
            };

            /*if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }*/

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(secretBytes),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,               // notBefore
                               DateTime.Now.AddMinutes(10)));  // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}