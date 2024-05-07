﻿using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Ecom.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
         await _context.Set<T>().AddAsync(entity);
         await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        //ASNOTRAKING=>بيسرع عمليه البحث بمعني الانتتي بيرجع من غير ما يغمل تراك للستيت
        public IEnumerable<T> GetAll()
       => _context.Set<T>().AsNoTracking().ToList();
        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
                //apply any include
            foreach(var item in includes)
            {
              query = query.Include(item);
            }
            return await query.ToListAsync();
           
        }

        public async Task <T> GetAsync(T id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(T id, params Expression<Func<T, object>>[] includes)
        {
           //var query = _context.Set<T>().AsQueryable();
            IQueryable<T> query = _context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await ((DbSet<T>)query).FindAsync(id);
        }

        public async Task UpdateAsync(T id, T entity)
        {
            var exitingEntity =await _context.Set<T>().FindAsync(id);
            if (exitingEntity is not null)
            {
                _context.Update(exitingEntity);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}