﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Save()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int id)
        {
            var model = await _context.Set<T>().FirstOrDefaultAsync();
            if (model is not null)
            {
                model.IsActive = false;
                _context.Entry(model).State = EntityState.Modified;
            }
        }
    }
}
