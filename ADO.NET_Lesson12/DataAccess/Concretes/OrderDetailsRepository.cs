using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public void Add(OrderDetails data)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderDetails data)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetails data)
        {
            throw new NotImplementedException();
        }
    }
}
