using ADO.NET_Lesson12.DataAccess.Entities;
using ADO.NET_Lesson12.Domain.Commands;
using ADO.NET_Lesson12.Domain.Helpers;
using ADO.NET_Lesson12.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ADO.NET_Lesson12.Domain.ViewModels
{
    public class ProductInfoWindowViewModel : BaseViewModel
    {
        public RelayCommand OrderCommand { get; set; }

        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }


        public ProductInfoWindowViewModel(Product _product)
        {
            Product = _product;
            ImagePath = ImageHelpers.GetImagePath(Product.Category.Picture, Product.Category.CategoryID);

            OrderCommand = new RelayCommand((o) =>
            {
                var vm = new OrderViewModel(Product);
                var view = new OrderWindow();
                view.DataContext = vm;
                view.Show();
            });
        }
    }
}
