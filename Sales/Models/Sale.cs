using Sales.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class Sale : ValidatableBindableBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _clientID;
        public int ClientID
        {
            get { return _clientID; }
            set { SetProperty(ref _clientID, value); }
        }

        private int _salespersonID;
        public int SalespersonID
        {
            get { return _salespersonID; }
            set { SetProperty(ref _salespersonID, value); }
        }

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

        private decimal? _cost;
        public decimal? Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        private decimal? _price;
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal? Price
        {
            get { return _price; }
            set
            {
                SetProperty(ref _price, value);
                OnPropertyChanged("PriceTotal");
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _oldDebt;//المتبقى من قبل
        [Required]
        public decimal? OldDebt
        {
            get { return _oldDebt; }
            set
            {
                SetProperty(ref _oldDebt, value);
                OnPropertyChanged("PriceTotal");
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _priceTotal; // اجمالى المطلوب
        public decimal? PriceTotal
        {
            get { return _priceTotal = Price - OldDebt; }
            set
            {
                SetProperty(ref _priceTotal, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _cashPaid;//ما تم سداده
        [Required(ErrorMessage = "ما تم سداده مطلوب")]
        public decimal? CashPaid
        {
            get { return _cashPaid; }
            set
            {
                SetProperty(ref _cashPaid, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _discountPaid;
        [Required(ErrorMessage = "المدفوع من خلال الخصم مطلوب")]
        public decimal? DiscountPaid
        {
            get { return _discountPaid; }
            set
            {
                SetProperty(ref _discountPaid, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _newDebt;
        public decimal? NewDebt
        {
            get { return _newDebt = CashPaid + DiscountPaid - PriceTotal; }
            set { SetProperty(ref _newDebt, value); }
        }

        public virtual Client Client { get; set; }
        public virtual Salesperson Salesperson { get; set; }
        public virtual ICollection<SaleCategory> SaleCategories { get; set; }
        public virtual ICollection<SaleRecall> SaleRecalls { get; set; }

    }
}
