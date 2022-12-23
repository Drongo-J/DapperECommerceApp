using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class CustomerRepository : ICustomerRepository
    {
        public int Add(Customer data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer data)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
