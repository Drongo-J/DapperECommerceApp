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

        public void Add(OrderDetails data)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "INSERT INTO [Order Details] ([OrderID], [ProductID],[Quantity],[UnitPrice],[Discount]) " +
                          "VALUES (@orderId, @productId, @quantity, @unitPrice, @discount)";


                var id = App.DB.OrderDetailsRepository.GetAll().Max(od => od.OrderID) + 1;
                connection.Execute(sql, new 
                {
                    @orderId = id,
                    @productId = data.ProductID,
                    @quantity = data.Quantity,
                    @unitPrice = data.UnitPrice,
                    @discount = data.Discount
                });
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
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM [Order Details] AS OD " +
                          "INNER JOIN Orders AS O " +
                          "ON O.OrderID = OD.OrderID " +
                          "INNER JOIN Products AS P " +
                          "ON P.ProductID = OD.ProductID ";

                var orderdetails = connection.Query<OrderDetails, Order, Product, OrderDetails>(sql,
                    (orderdetail, order, product) =>
                    {
                        orderdetail.OrderID = order.OrderID;
                        orderdetail.ProductID = product.ProductID;
                        return orderdetail;
                    },
                    splitOn: "OrderID,ProductID"
                    );

                return orderdetails;
            }
        }

        public void Update(OrderDetails data)
        {
            throw new NotImplementedException();
        }
    }
}
