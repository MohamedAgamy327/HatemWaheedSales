using Sales.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class SaleCategory : ValidatableBindableBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _categoryID;
        //[Key, Column(Order = 1)]
        public int CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private int _saleID;
        //[Key, Column(Order = 2)]
        public int SaleID
        {
            get { return _saleID; }
            set { SetProperty(ref _saleID, value); }
        }

        private decimal? _qty;
        public decimal? Qty
        {
            get { return _qty; }
            set { SetProperty(ref _qty, value); }
        }

        private decimal? _cost;
        public decimal? Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private decimal? _costTolal;
        public decimal? CostTotal
        {
            get { return _costTolal; }
            set { SetProperty(ref _costTolal, value); }
        }

        private decimal? _priceTolal;
        public decimal? PriceTotal
        {
            get { return _priceTolal; }
            set { SetProperty(ref _priceTolal, value); }
        }

        public virtual Sale Sale { get; set; }
        public virtual Category Category { get; set; }
    }
    public class SaleCategoryVM : ValidatableBindableBase
    {
        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        private int _saleID;
        public int SaleID
        {
            get { return _saleID; }
            set { SetProperty(ref _saleID, value); }
        }

        private decimal? _qty;
        [Required(ErrorMessage = "الكمية مطلوبة")]
        public decimal? Qty
        {
            get { return _qty; }
            set { SetProperty(ref _qty, value); }
        }

        private decimal? _cost;
        public decimal? Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        private decimal? _costTolal;
        public decimal? CostTotal
        {
            get { return _costTolal = Qty * Cost; }
            set { SetProperty(ref _costTolal, value); }
        }

        private decimal? _price;
        [Required(ErrorMessage = "السعر مطلوب")]
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private decimal? _priceTolal;
        public decimal? PriceTotal
        {
            get { return _priceTolal = Qty * Price; }
            set { SetProperty(ref _priceTolal, value); }
        }

    }

}
