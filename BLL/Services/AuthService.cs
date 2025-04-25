using BLL.DTO;
using BLL.Interfaces;
using DAL.ApplicationDbContext;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtSettingsDTO _jwtSettings;

        public AuthService(AppDbContext context, IOptions<JwtSettingsDTO> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> LoginAsync(Login model)
        {
            var manager = await _context.Managers
                .FirstOrDefaultAsync(m => m.ManagerEmail == model.Email);

            if (manager == null)
                throw new Exception("Kullanıcı bulunamadı!");

            if (!VerifyPassword(model.Password, manager.Password)) 
                throw new Exception("Şifre hatalı!");

            return GenerateJwtToken(manager);
        }

        public async Task<string> RegisterAsync(ManagersDTO model)
        {
            var managers = _context.Managers.Where(x => x.CompanyID == model.CompanyID);
            if (managers.Count() == 0)
            {
                model.AddPermission = true;
                model.ListPermission = true;
                model.UpdatePermission = true;
                model.DeletePermission = true;
            }

            if (await _context.Managers.AnyAsync(m => m.ManagerEmail == model.ManagerEmail))
                throw new Exception("Bu email adresiyle bir kullanıcı zaten var.");

            var hashedPassword = HashPassword(model.Password);

            var manager = new Managers
            {
                ManagerName = model.ManagerName,
                ManagerSurname = model.ManagerSurname,
                ManagerEmail = model.ManagerEmail,
                ManagerTel = model.ManagerTel,
                Password = hashedPassword,
                CompanyID = model.CompanyID,
                AddPermission = model.AddPermission,
                UpdatePermission = model.UpdatePermission,
                DeletePermission = model.DeletePermission,
                ListPermission = model.ListPermission,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now 
            };

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return GenerateJwtToken(manager);
        }

        private string GenerateJwtToken(Managers manager)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, manager.ManagerName),
                new Claim(ClaimTypes.Email, manager.ManagerEmail),
                new Claim(ClaimTypes.Role, "Manager"),
                new Claim("AddPermission", manager.AddPermission.ToString()),
                new Claim("UpdatePermission", manager.UpdatePermission.ToString()),
                new Claim("DeletePermission", manager.DeletePermission.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(enteredPassword);
                var hash = sha256.ComputeHash(bytes);
                var enteredHash = Convert.ToBase64String(hash);
                return enteredHash == storedHash;
            }
        }
    }
}
