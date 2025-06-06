﻿using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IManagerRepository : IBaseRepository<Managers>
    {
        Task<Companies> GetManagersCompany(int managerID);
    }
}
