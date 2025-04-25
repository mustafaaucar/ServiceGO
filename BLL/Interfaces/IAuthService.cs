using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(Login model);
        Task<string> RegisterAsync(ManagersDTO model);
    }
}
