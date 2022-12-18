using ADO.NET_Lesson12.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {

    }
}
