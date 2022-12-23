using ADO.NET_Lesson12.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository => new CategoryRepository();

        public IProductRepository ProductRepository => new ProductRepository();

        public IOrderRepository OrderRepository => new OrderRepository();

        public IOrderDetailsRepository OrderDetailsRepository => new OrderDetailsRepository();
    }
}
