using Sales.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class SupplyRecall : ValidatableBindableBase
    {
        private DateTime _registrationDate;
        [Key]
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { SetProperty(ref _registrationDate, value); }
        }

        private DateTime _date;
        [Column(TypeName = "Date")]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private int _supplyID;
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
            set
            {
                SetProperty(ref _cost, value);
            }
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
    public class SupplyRecallVM : ValidatableBindableBase
    {
        private DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { SetProperty(ref _registrationDate, value); }
        }

        private DateTime _date;
        [Column(TypeName = "Date")]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

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
        public decimal? Cost
        {
            get { return _cost; }
            set
            {
                SetProperty(ref _cost, value);
            }
        }

        private decimal? _costTolal;
        public decimal? CostTotal
        {
            get { return _costTolal = Qty * Cost; }
            set { SetProperty(ref _costTolal, value); }
        }
    }

}
