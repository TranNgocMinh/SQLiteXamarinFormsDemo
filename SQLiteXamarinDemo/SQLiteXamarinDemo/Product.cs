using System.ComponentModel;
using SQLite;

namespace SQLiteXamarinDemo
{
    [Table("Products")]
    class Product
    {
        private int _id;
        [PrimaryKey]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _productName;
        [NotNull]
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                this._productName = value;
            }
        }
    }
}

