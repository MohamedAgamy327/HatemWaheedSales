using Sales.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    public class ClientAccount : ValidatableBindableBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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

        private int _clientID;
        [Required(ErrorMessage ="العميل مطلوب")]
        public int ClientID
        {
            get { return _clientID; }
            set { SetProperty(ref _clientID, value); }
        }

        private string _statement;
        public string Statement
        {
            get { return _statement; }
            set { SetProperty(ref _statement, value); }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        private decimal? _debit;
        public decimal? Debit
        {
            get { return _debit; }
            set { SetProperty(ref _debit, value); }
        }

        private decimal? _credit;
        public decimal? Credit
        {
            get { return _credit; }
            set { SetProperty(ref _credit, value); }
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get { return _canDelete; }
            set { SetProperty(ref _canDelete, value); }
        }

        public virtual Client Client { get; set; }

    }

    public class ClientAccountVM : ValidatableBindableBase
    {
        private decimal? _totalDebit;
        public decimal? TotalDebit
        {
            get { return _totalDebit; }
            set { SetProperty(ref _totalDebit, value); }
        }

        private decimal? _totalCredit;
        public decimal? TotalCredit
        {
            get { return _totalCredit; }
            set { SetProperty(ref _totalCredit, value); }
        }

        private decimal? _duringAccount;
        public decimal? DuringAccount
        {
            get { return _duringAccount; }
            set { SetProperty(ref _duringAccount, value); }
        }

        private decimal? _oldAccount;
        public decimal? OldAccount
        {
            get { return _oldAccount; }
            set { SetProperty(ref _oldAccount, value); }
        }

        private decimal? _currentAccount;
        public decimal? CurrentAccount
        {
            get { return _currentAccount; }
            set { SetProperty(ref _currentAccount, value); }
        }

    }
}
