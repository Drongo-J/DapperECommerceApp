using ADO.NET_Lesson12.DataAccess.Entities;
using ADO.NET_Lesson12.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ADO.NET_Lesson12.Domain.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public RelayCommand SubmitCommand { get; set; }

        private OrderDetails orderDetails;

        public OrderDetails OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }

        private ObservableCollection<string> countries;

        public ObservableCollection<string> Countries
        {
            get { return countries; }
            set { countries = value; OnPropertyChanged(); }
        }

        private string selectedCountry = string.Empty;

        public string SelectedCountry
        {
            get { return selectedCountry; }
            set { selectedCountry = value; OnPropertyChanged(); }
        }


        public OrderViewModel(Product product)
        {
            OrderDetails = new OrderDetails();
            OrderDetails.UnitPrice = product.UnitPrice;
            OrderDetails.ProductID = product.ProductID;
            var AllOrders = App.DB.OrderRepository.GetAll();
            Countries = new ObservableCollection<string>(AllOrders.Select(o => o.ShipCountry).Distinct().ToList());

            Order _order = new Order();
            _order.ShipCountry = SelectedCountry;

            _order.EmployeeID = 1;
            _order.CustomerID = "ALFKI";
            _order.ShipVia = 1;
            _order.Freight = 1212.21123123M;
            _order.ShipName = "ShipName";
            _order.ShipAdress = "Adress";
            _order.ShipCity = "City";
            _order.ShipRegion = "Region";
            _order.ShipPostalCode = "PostalCode";
            _order.OrderDate = DateTime.Now;
            _order.RequiredDate = DateTime.Now;
            _order.ShippedDate = DateTime.Now;

            SubmitCommand = new RelayCommand((s) =>
            {
                if (SelectedCountry != null && SelectedCountry.Trim() != string.Empty)
                {
                    if (OrderDetails.Quantity > 0)
                    {
                        var id = AllOrders.Max(o => o.OrderID) + 1;
                        _order.OrderID= id;
                        OrderDetails.OrderID = id;
                        App.DB.OrderRepository.Add(_order);
                        App.DB.OrderDetailsRepository.Add(OrderDetails);
                        MessageBox.Show("Order was added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Quantity Must Be Greater Than 0!");
                    }
                }
                else
                {
                    MessageBox.Show("Select Country");
                }
            });
        }
    }
}
