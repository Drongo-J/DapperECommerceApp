using ADO.NET_Lesson12.DataAccess.Entities;
using ADO.NET_Lesson12.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ADO.NET_Lesson12.Domain.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
		public RelayCommand SubmitCommand { get; set; }

        private OrderDetails order;

		public OrderDetails Order
        {
			get { return order; }
			set { order = value; }
		}


		public OrderViewModel(Product product)
		{
			Order = new OrderDetails();
			Order.UnitPrice = product.UnitPrice;

			SubmitCommand = new RelayCommand((s) =>
			{

			});
		}
	}
}
