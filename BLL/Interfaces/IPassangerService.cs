﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPassangerService
    {
        Task AddPassangersAsync(PassangersDTO model);
        Task<IEnumerable<PassangersDTO>> GetCompanyPassangers(int companyID);
    }
}
