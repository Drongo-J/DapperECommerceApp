using ADO.NET_Lesson12.DataAccess.Entities;
using ADO.NET_Lesson12.Domain.Commands;
using ADO.NET_Lesson12.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Lesson12.Domain.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
		public RelayCommand SelectedCommand { get; set; }

        private ObservableCollection<Product> allProducts;

		public ObservableCollection<Product> AllProducts
        {
			get { return allProducts; }
			set { allProducts = value; OnPropertyChanged(); }
		}

		private Product selectedProduct;

		public Product SelectedProduct
		{
			get { return selectedProduct; }
			set { selectedProduct = value; OnPropertyChanged(); }
		}

		public HomeViewModel()
		{
			AllProducts = new ObservableCollection<Product>(App.DB.ProductRepository.GetAll());
			SelectedProduct = new Product();

			SelectedCommand = new RelayCommand((s) =>
			{
				var productInfoWindow = new ProductInfoWindow();
				var productInfoWindowViewModel = new ProductInfoWindowViewModel(SelectedProduct);
				productInfoWindow.DataContext = productInfoWindowViewModel;
				productInfoWindow.Show();

			});

        }

	}
}
