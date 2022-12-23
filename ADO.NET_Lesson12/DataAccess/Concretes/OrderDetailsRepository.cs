using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private string ConnectionString { get; set; }

        public OrderDetailsRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public int Add(OrderDetails data)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "INSERT INTO [Order Details] ([OrderID], [ProductID],[Quantity],[UnitPrice],[Discount]) " +
                          "VALUES (@orderId, @productId, @quantity, @unitPrice, @discount)";

                var id = connection.QuerySingle<int>(sql, new 
                {
                    @orderId = data.OrderID,
                    @productId = data.ProductID,
                    @quantity = data.Quantity,
                    @unitPrice = data.UnitPrice,
                    @discount = data.Discount
                });
                return id;
            }
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
