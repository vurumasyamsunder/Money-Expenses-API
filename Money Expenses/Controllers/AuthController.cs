using Microsoft.AspNetCore.Mvc;
using Money_Expenses.DTOs;
using Money_Expenses.DAL;
using System.Security.Cryptography;
using System.Text;
using Money_Expenses.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Npgsql;

namespace Money_Expenses.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest request)
        public IActionResult Login([FromBody] LoginDTO request)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            string query = "";
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                 query = "select count(*) FROM users where username = '"+request.Username + "' and passwordhash = '"+ request.Password + "' ";

                using (var cmd = new NpgsqlCommand(query, con)) {
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (userCount > 0) {
                        var token = GenerateJwtToken(request.Username);
             
                        return Ok(new { token });

                    }
                    else
                    {
                        return Unauthorized("Invalid credentials");
                    }
                }
                
            }
        }


        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User")
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }





}
       


   
