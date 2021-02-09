using Sales.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class SupplyCategory : ValidatableBindableBase
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

        private int _supplyID;
        //[Key, Column(Order = 2)]
        public int SupplyID
        {
            get { return _supplyID; }
            set { SetProperty(ref _supplyID, value); }
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

        public virtual Supply Supply { get; set; }
        public virtual Category Category { get; set; }
    }
    public class SupplyCategoryVM : ValidatableBindableBase
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

        private int _supplyID;
        public int SupplyID
        {
            get { return _supplyID; }
            set { SetProperty(ref _supplyID, value); }
        }

        private decimal? _qty;
        [Required(ErrorMessage = "الكمية مطلوبة")]
        public decimal? Qty
        {
            get { return _qty; }
            set { SetProperty(ref _qty, value); }
        }

        private decimal? _cost;
        [Required(ErrorMessage = "التكلفة مطلوبة")]
        public decimal? Cost
        {
            get { return _cost; }
            set
            {
                SetProperty(ref _cost, value);
            }
        }

        private decimal? _price;
        [Required(ErrorMessage = "السعر  مطلوب")]
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private decimal? _costTolal;
        public decimal? CostTotal
        {
            get { return _costTolal = Qty * Cost; }
            set { SetProperty(ref _costTolal, value); }
        }
      
    }

}
