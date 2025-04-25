using DAL.ApplicationDbContext;
using DAL.IRepositories;
using DAL.IRepository;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly AppDbContext _context;

        public CompaniesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Companies entity)
        {
            await _context.Companies.AddAsync(entity);
        }

        public void Delete(Companies entity)
        {
            _context.Companies.Remove(entity);
        }

        public async Task<Companies> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Companies>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public void Update(Companies entity)
        {
            _context.Companies.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
