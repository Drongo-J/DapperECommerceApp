using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class OrderRepository : IOrderRepository
    {
        private string ConnectionString { get; set; }

        public OrderRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public void Add(Order data)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "INSERT INTO Orders ([CustomerID],[EmployeeID],[Freight],[OrderDate],[RequiredDate],[ShipAddress],[ShipCity],[ShipCountry],[ShipName],[ShippedDate],[ShipPostalCode],[ShipVia],[ShipRegion]) " +
                                         "VALUES (@customerId, @employeeID, @freight, @orderDate, @requiredDate, @shipAdress, @shipCity, @shipCountry, @shipName, @shippedDate, @shipPostalCode, @shipVia,@shipRegion)";

                connection.Execute(sql, new
                                                {
                                                    @customerId = data.CustomerID,
                                                    @employeeID = data.EmployeeID,
                                                    @freight = data.Freight,
                                                    @orderDate = data.OrderDate,
                                                    @requiredDate = data.RequiredDate,
                                                    @shipAdress = data.ShipAdress,
                                                    @shipCity = data.ShipCity,
                                                    @shipCountry = data.ShipCountry,
                                                    @shipName = data.ShipName,
                                                    @shippedDate = data.ShippedDate,
                                                    @shipPostalCode = data.ShipPostalCode,
                                                    @shipVia = data.ShipVia,
                                                    @shipRegion = data.ShipRegion});

            }
        }

        public void Delete(Order data)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Orders AS O " +
                          "INNER JOIN Customers AS C " +
                          "ON O.CustomerID = C.CustomerID " +
                          "INNER JOIN Employees AS E " +
                          "ON O.EmployeeID = E.EmployeeID " +
                          "INNER JOIN Shippers AS S " +
                          "ON O.ShipVia = S.ShipperID";

                var orders = connection.Query<Order, Customer, Employee, Shipper, Order>(sql,
                    (order, customer, employee, shipper) =>
                    {
                        order.Customer = customer;
                        order.Employee = employee;
                        order.Shipper = shipper;
                        return order;
                    },
                    splitOn: "CustomerID,EmployeeID,ShipperID"
                    );

                return orders;
            }
        }

        public void Update(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
