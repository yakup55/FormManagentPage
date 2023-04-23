using CoreLayer.Model;
using CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class FormRepository : GenericRepository<Form>, IFormRepository
    {
        public FormRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Form>> FormUser(string userId)
        {
            return await context.Forms.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Form>> SearachForm(string form)
        {
            return await context.Forms.Where(x=>x.FormName.Contains(form)||x.FormDescription.Contains(form)||x.UserId.Contains(form)).ToListAsync();   
        }
    }
}
