using CoreLayer.UnitOfWork;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CommintAsync()
        {
            await context.SaveChangesAsync();   
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
