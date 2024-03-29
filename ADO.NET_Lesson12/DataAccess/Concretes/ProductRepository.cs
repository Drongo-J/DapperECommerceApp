﻿using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString { get; set; }

        public ProductRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        public void Add(Product data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product data)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Products AS P
                            INNER JOIN Categories AS C
                            ON P.CategoryID = C.CategoryID
                            WHERE P.ProductID=@id";

                var products = conn.Query<Product, Category, Product>(sql,
                                (product, category) =>
                                {
                                    product.Category = category;
                                    return product;
                                },new {id=id}, splitOn: "CategoryID");

                    
                return products.First();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Products AS P
                            INNER JOIN Categories AS C
                            ON P.CategoryID = C.CategoryID";

                var products = conn.Query<Product, Category, Product>(sql,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    }, splitOn: "CategoryID");

                return products;
            }
        }

        public void Update(Product data)
        {
            throw new NotImplementedException();
        }
    }
}
