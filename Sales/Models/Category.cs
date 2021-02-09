using Sales.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class Category : ValidatableBindableBase
    {
        public Category()
        {
            Isarchived = false;
        }
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _companyID;
        [Required(ErrorMessage ="اسم الشركة مطلوب")]
        public int CompanyID
        {
            get { return _companyID; }
            set { SetProperty(ref _companyID, value); }
        }

        private int _stockID;
        public int StockID
        {
            get { return _stockID; }
            set { SetProperty(ref _stockID, value); }
        }

        private string _name;
        [Required(ErrorMessage = "اسم الصنف مطلوب")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        private decimal? _qtyStart;
        [Required(ErrorMessage = "رصيد بداية المدة مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal? QtyStart
        {
            get { return _qtyStart; }
            set { SetProperty(ref _qtyStart, value); }
        }

        private decimal? _qty;
        public decimal? Qty
        {
            get { return _qty; }
            set { SetProperty(ref _qty, value); }
        }

        private decimal? _requestLimit;
        [Required(ErrorMessage = "حد الطلب مطلوب")]
        public decimal? RequestLimit
        {
            get { return _requestLimit; }
            set { SetProperty(ref _requestLimit, value); }
        }

        private decimal? _price;
        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private decimal? _cost;
        [Required(ErrorMessage = "التكلفة مطلوبة")]
        [Range(0, double.MaxValue)]
        public decimal? Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        private bool? _isarchived;
        public bool? Isarchived
        {
            get { return _isarchived; }
            set { SetProperty(ref _isarchived, value); }
        }



        public virtual Company Company { get; set; }
        public virtual Stock Stock { get; set; }

        public virtual ICollection<SupplyCategory> SuppliesCategories { get; set; }
        public virtual ICollection<SupplyRecall> SuppliesRecalls { get; set; }
        public virtual ICollection<SaleCategory> SalesCategories { get; set; }
        public virtual ICollection<SaleRecall> SalesRecalls { get; set; }
    }

    public class CategoryVM : ValidatableBindableBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private bool? _isarchived;
        public bool? Isarchived
        {
            get { return _isarchived; }
            set { SetProperty(ref _isarchived, value); }
        }


        private int _companyID;
        public int CompanyID
        {
            get { return _companyID; }
            set { SetProperty(ref _companyID, value); }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        private int _stockID;
        public int StockID
        {
            get { return _stockID; }
            set { SetProperty(ref _stockID, value); }
        }

        private string _stock;
        public string Stock
        {
            get { return _stock; }
            set { SetProperty(ref _stock, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        private decimal? _qtyStart;
        public decimal? QtyStart
        {
            get { return _qtyStart; }
            set { SetProperty(ref _qtyStart, value); }
        }

        private decimal? _qty;
        public decimal? Qty
        {
            get { return _qty; }
            set { SetProperty(ref _qty, value); }
        }

        private decimal? _requestLimit;
        public decimal? RequestLimit
        {
            get { return _requestLimit; }
            set { SetProperty(ref _requestLimit, value); }
        }

        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private decimal? _cost;
        public decimal? Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        private decimal? _totalPrice;
        public decimal? TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        private decimal? _totalCost;
        public decimal? TotalCost
        {
            get { return _totalCost; }
            set { SetProperty(ref _totalCost, value); }
        }

        private decimal? _supplyQty;
        public decimal? SupplyQty
        {
            get { return _supplyQty; }
            set { SetProperty(ref _supplyQty, value); }
        }

        private decimal? _saleQty;
        public decimal? SaleQty
        {
            get { return _saleQty; }
            set { SetProperty(ref _saleQty, value); }
        }

        private decimal? _supplyCost;
        public decimal? SupplyCost
        {
            get { return _supplyCost; }
            set { SetProperty(ref _supplyCost, value); }
        }

        private decimal? _salePrice;
        public decimal? SalePrice
        {
            get { return _salePrice; }
            set { SetProperty(ref _salePrice, value); }
        }

        private decimal _requiredQty;
        public decimal RequiredQty
        {
            get { return _requiredQty; }
            set { SetProperty(ref _requiredQty, value); }
        }
    }
}
