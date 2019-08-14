using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteXamarinDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductsPage : ContentPage
	{
        private DataHandler dataAccess;
        public ProductsPage ()
		{
			InitializeComponent ();
            this.dataAccess = new DataHandler();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // The instance of CustomersDataAccess
            // is the data binding source
            this.BindingContext = this.dataAccess;
        }
        private void OnShowAllClick(object sender, EventArgs e)
        {
            this.dataAccess = new DataHandler();
            this.BindingContext = this.dataAccess;
        }
        private void OnSaveClick(object sender, EventArgs e)
        {
            var p = this.ProductsView.SelectedItem as Product;
            if(p!= null)
                this.dataAccess.SaveProduct(p);
        }
        private void OnSaveAllClick(object sender, EventArgs e)
        {          
                this.dataAccess.SaveAllProduct();
        }
        private void OnAddClick(object sender, EventArgs e)
        {
            this.dataAccess.AddNewProduct();
        }
        private void OnRemoveClick(object sender, EventArgs e)
        {
            var p = this.ProductsView.SelectedItem as Product;
            if (p != null)
                this.dataAccess.DeleteProduct(p);
        }
        private async void OnRemoveAllClick(object sender, EventArgs e)
        {
            if (this.dataAccess.Products.Any())
            {
                var result =
                  await DisplayAlert("Confirmation",
                  "Are you sure? This cannot be undone",
                  "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllProducts();
                    this.dataAccess = new DataHandler();
                    this.BindingContext = this.dataAccess;
                }
            }
        }
        
    }
}