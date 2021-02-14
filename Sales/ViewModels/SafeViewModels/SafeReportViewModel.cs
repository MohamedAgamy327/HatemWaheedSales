using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.SafeViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sales.ViewModels.SafeViewModels
{
    public class SafeReportViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        SafeServices _safeServ;

        List<Safe> safes;

        private readonly SafeDetailsDialog _safeDetailsDialog;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = safes.Where(w => (w.Statement).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            TotalIncome = safes.Where(w => w.Amount > 0 && w.Statement.Contains(_key)).Sum(s => s.Amount); 
            TotalOutgoings = safes.Where(w => w.Amount < 0 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            GetCurrentPage();
        }

        public SafeReportViewModel()
        {
      
            _safeServ = new SafeServices();
            _safeDetailsDialog = new SafeDetailsDialog();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _dateFrom = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _dateTo = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _currentAccount = _safeServ.GetCurrentAccount();
            safes = _safeServ.GetSafes(_dateFrom, _dateTo);
            Load();
        }

        private bool _isFocused ;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetProperty(ref _isFocused, value); }
        }

        private bool _isFirst;
        public bool ISFirst
        {
            get { return _isFirst; }
            set { SetProperty(ref _isFirst, value); }
        }

        private bool _isLast;
        public bool ISLast
        {
            get { return _isLast; }
            set { SetProperty(ref _isLast, value); }
        }

        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { SetProperty(ref _currentPage, value); }
        }

        private int _lastPage;
        public int LastPage
        {
            get { return _lastPage; }
            set { SetProperty(ref _lastPage, value); }
        }

        private decimal? _currentAccount;
        public decimal? CurrentAccount
        {
            get { return _currentAccount; }
            set { SetProperty(ref _currentAccount, value); }
        }

        private decimal? _totalIncome;
        public decimal? TotalIncome
        {
            get { return _totalIncome; }
            set
            {
                SetProperty(ref _totalIncome, value);
                OnPropertyChanged("Difference");
            }
        }

        private decimal? _totalOutgoings;
        public decimal? TotalOutgoings
        {
            get { return _totalOutgoings; }
            set
            {
                SetProperty(ref _totalOutgoings, value);
                OnPropertyChanged("Difference");
            }
        }

        private decimal? _difference;
        public decimal? Difference
        {
            get { return _difference = _totalIncome + _totalOutgoings; }
            set { SetProperty(ref _difference, value); }
        }

        private int _totalRecords;
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { SetProperty(ref _totalRecords, value); }
        }

        private decimal? _safeItem;
        public decimal? SafeItem
        {
            get { return _safeItem; }
            set { SetProperty(ref _safeItem, value); }
        }

        private decimal? _supplyItem;
        public decimal? SupplyItem
        {
            get { return _supplyItem; }
            set { SetProperty(ref _supplyItem, value); }
        }

        private decimal? _saleItem;
        public decimal? SaleItem
        {
            get { return _saleItem; }
            set { SetProperty(ref _saleItem, value); }
        }

        private decimal? _spendingItem;
        public decimal? SpendingItem
        {
            get { return _spendingItem; }
            set { SetProperty(ref _spendingItem, value); }
        }

        private decimal? _accountCatchItem;
        public decimal? AccountCatchItem
        {
            get { return _accountCatchItem; }
            set { SetProperty(ref _accountCatchItem, value); }
        }

        private decimal? _accountPayItem;
        public decimal? AccountPayItem
        {
            get { return _accountPayItem; }
            set { SetProperty(ref _accountPayItem, value); }
        }

        private decimal? _debtPayItem;
        public decimal? DebtPayItem
        {
            get { return _debtPayItem; }
            set { SetProperty(ref _debtPayItem, value); }
        }

        private decimal? _debtCatchItem;
        public decimal? DebtCatchItem
        {
            get { return _debtCatchItem; }
            set { SetProperty(ref _debtCatchItem, value); }
        }

        private decimal? _premiumPayItem;
        public decimal? PremiumPayItem
        {
            get { return _premiumPayItem; }
            set { SetProperty(ref _premiumPayItem, value); }
        }

        private string _key ;
        public string Key
        {
            get { return _key; }
            set
            {
                SetProperty(ref _key, value);
            }
        }

        private DateTime _dateTo;
        public DateTime DateTo
        {
            get { return _dateTo; }
            set { SetProperty(ref _dateTo, value); }
        }

        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { SetProperty(ref _dateFrom, value); }
        }

        private ObservableCollection<Safe> _safes;
        public ObservableCollection<Safe> Safes
        {
            get { return _safes; }
            set { SetProperty(ref _safes, value); }
        }

        // Display

        private RelayCommand _search;
        public RelayCommand Search
        {
            get
            {
                return _search
                    ?? (_search = new RelayCommand(SearchMethod));
            }
        }
        private void SearchMethod()
        {
            Load();
        }

        private RelayCommand _searcByDate;
        public RelayCommand SearchByDate
        {
            get
            {
                return _searcByDate
                    ?? (_searcByDate = new RelayCommand(SearchByDateMethod));
            }
        }
        private void SearchByDateMethod()
        {
            safes = _safeServ.GetSafes(_dateFrom, _dateTo);
            Load();
        }

        private RelayCommand _next;
        public RelayCommand Next
        {
            get
            {
                return _next
                    ?? (_next = new RelayCommand(NextMethod));
            }
        }
        private void NextMethod()
        {
            CurrentPage++;
            ISFirst = true;
            if (_currentPage == _lastPage)
                ISLast = false;
            GetCurrentPage();
        }

        private RelayCommand _previous;
        public RelayCommand Previous
        {
            get
            {
                return _previous
                    ?? (_previous = new RelayCommand(PreviousMethod));
            }
        }
        private void PreviousMethod()
        {
            CurrentPage--;
            ISLast = true;
            if (_currentPage == 1)
                ISFirst = false;
            GetCurrentPage();
        }

        //Report

        private RelayCommand _showDetails;
        public RelayCommand ShowDetails
        {
            get
            {
                return _showDetails
                    ?? (_showDetails = new RelayCommand(ShowDetailsMethod));
            }
        }
        private async void ShowDetailsMethod()
        {
            SafeItem = safes.Where(w => w.Source == 1 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            SpendingItem = safes.Where(w => w.Source == 2 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            SupplyItem = safes.Where(w => w.Source == 3 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            SaleItem = safes.Where(w => w.Source == 4 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            AccountPayItem = safes.Where(w => w.Source == 5 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            AccountCatchItem = safes.Where(w => w.Source == 6 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            DebtPayItem = safes.Where(w => w.Source == 7 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            DebtCatchItem = safes.Where(w => w.Source == 8 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            PremiumPayItem = safes.Where(w => w.Source == 9 && w.Statement.Contains(_key)).Sum(s => s.Amount);
            _safeDetailsDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_safeDetailsDialog);
        }

        private RelayCommand<string> _closeDialog;
        public RelayCommand<string> CloseDialog
        {
            get
            {
                return _closeDialog
                    ?? (_closeDialog = new RelayCommand<string>(ExecuteCloseDialogAsync));
            }
        }
        private async void ExecuteCloseDialogAsync(string parameter)
        {
            switch (parameter)
            {
                case "Details":
                    await _currentWindow.HideMetroDialogAsync(_safeDetailsDialog);
                    break;
                default:
                    break;
            }

        }

        private void GetCurrentPage()
        {
            Safes = new ObservableCollection<Safe>(safes.Where(w => w.Statement.Contains(_key)).OrderByDescending(o => o.RegistrationDate).Skip((_currentPage - 1) * 17).Take(17));
        }
    }
}
