using CoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repository
{
    public interface IFormRepository:IGenericRepository<Form>
    {
        Task<List<Form>> FormUser(string userId);
        Task<List<Form>> SearachForm(string form);
    }
}
