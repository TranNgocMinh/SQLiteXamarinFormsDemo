using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SQLiteXamarinDemo
{
    class DataHandler
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Product> Products { get; set; }
        public DataHandler()
        {
            database = 
              DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Product>();
            this.Products = new ObservableCollection<Product>(database.Table<Product>());
            // If the table is empty, initialize the collection
            if (!database.Table<Product>().Any())
            {
                AddNewProduct();            
            }
        }
        public void AddNewProduct()
        {
            Product p = new Product()
            {
                Id = 0, 
                ProductName = "Product name..."
            };
            this.Products.Add(p);
        }
        public void SaveProduct(Product p)
        {
          
            lock (collisionLock)
             {
                database.Insert(p);
            }
           
        }
        public void SaveAllProduct()
        {
            foreach (var p in this.Products)
            {
                lock (collisionLock)
                {
                    database.Insert(p);
                }
            }            
        }
        public void DeleteProduct(Product p)
        {
            var id = p.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Product>(id);
                }
            }
            this.Products.Remove(p);
           
        }
        public void DeleteAllProducts()
        {
            lock (collisionLock)
            {
                database.DropTable<Product>();
                database.CreateTable<Product>();
            }
            this.Products.Clear(); 
            this.Products = new ObservableCollection<Product>(database.Table<Product>());
        }
    }
}
