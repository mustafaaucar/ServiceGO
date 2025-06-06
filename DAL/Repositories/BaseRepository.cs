﻿using DAL.ApplicationDbContext;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BaseRepository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

		public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

		public async Task<T> AddAsync(T entity)
		{
			try
			{
                var entry = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entry.Entity;
            }
			catch (Exception ex)
			{
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
		{
            _dbSet.Remove(entity);
        }

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
