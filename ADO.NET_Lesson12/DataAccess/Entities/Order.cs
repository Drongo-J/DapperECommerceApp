﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.DataAccess.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public Shipper Shipper { get; set; }
        public decimal Freight{ get; set; }
        public string ShipName{ get; set; }
        public string ShipAdress{ get; set; }
        public string ShipCity{ get; set; }
        public string ShipRegion{ get; set; }
        public string ShipPostalCode{ get; set; }
        public string ShipCountry{ get; set; }
    }
}
