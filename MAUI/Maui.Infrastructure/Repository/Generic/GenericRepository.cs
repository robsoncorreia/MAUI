﻿using Maui.Infrastructure.Configuration.EF;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Repository.Generic
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly DbContextOptions<MauiContext> _dbContextOptions;

        public GenericRepository()
        {
            _dbContextOptions = new DbContextOptions<MauiContext>();
        }

        public async Task Add(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = await data.Set<T>().AddAsync(objeto);
            _ = await data.SaveChangesAsync();
        }

        public async Task Delete(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = data.Set<T>().Remove(objeto);
            _ = await data.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindById(int id)
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            using MauiContext data = new(_dbContextOptions);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T objeto)
        {
            using MauiContext data = new(_dbContextOptions);
            _ = data.Set<T>().Update(objeto);
            _ = await data.SaveChangesAsync();
        }
    }
}