using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DomainDbContext _context;
        public abstract DbSet<TEntity> Collection { get; set; }

        protected BaseRepository(DomainDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(TEntity obj, CancellationToken cancellationToken = default)
        {
            Collection.Add(obj);
        }

        public async Task<TEntity> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await Collection.FindAsync(id);
        }

        public void Update(TEntity obj, CancellationToken cancellationToken = default)
        {
            Collection.Update(obj);
        }

        public void Remove(int id, CancellationToken cancellationToken = default)
        {
            var obj = Collection.FirstOrDefault(entity => entity.Id == id);
            if (obj == null) throw new Exception("Id não encontrado");
            obj.DeletedAt = DateTimeOffset.UtcNow;
            Collection.Update(obj);
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
