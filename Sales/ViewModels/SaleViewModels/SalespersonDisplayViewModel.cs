using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.SaleViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sales.ViewModels.SaleViewModels
{
    public class SalespersonDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly SalespersonAddDialog _salespersonAddDialog;
        private readonly SalespersonUpdateDialog _salespersonUpdateDialog;
        private readonly SalespersonAccountShowDialog _salespersonAccountShowDialog;

        SaleServices _saleServ;
        SalespersonServices _salespersonServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = _salespersonServ.GetSalespersonsNumer(Key);
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)_salespersonServ.GetSalespersonsNumer(_key) / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            Salespersons = new ObservableCollection<Salesperson>(_salespersonServ.SearchSalespersons(_key, _currentPage));
        }

        public SalespersonDisplayViewModel()
        {
            _saleServ = new SaleServices();
            _salespersonServ = new SalespersonServices();
            _salespersonAddDialog = new SalespersonAddDialog();
            _salespersonAccountShowDialog = new SalespersonAccountShowDialog();
            _salespersonUpdateDialog = new SalespersonUpdateDialog();

            _key = "";
            _isFocused = true;
            _salespersonsSuggestions = _salespersonServ.GetSalespersonsSuggetions();
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            Load();
        }

        private bool _isFocused;
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

        private int _totalRecords;
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { SetProperty(ref _totalRecords, value); }
        }

        private decimal? _totalBillPrice;
        public decimal? TotalBillPrice
        {
            get { return _totalBillPrice; }
            set { SetProperty(ref _totalBillPrice, value); }
        }

        private string _key;
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

        private Salesperson _selectedSalesperson;
        public Salesperson SelectedSalesperson
        {
            get { return _selectedSalesperson; }
            set { SetProperty(ref _selectedSalesperson, value); }
        }

        private Salesperson _newSalesperson;
        public Salesperson NewSalesperson
        {
            get { return _newSalesperson; }
            set { SetProperty(ref _newSalesperson, value); }
        }

        private List<string> _salespersonsSuggestions;
        public List<string> SalespersonsSuggestions
        {
            get { return _salespersonsSuggestions; }
            set { SetProperty(ref _salespersonsSuggestions, value); }
        }

        private ObservableCollection<Salesperson> _salespersons;
        public ObservableCollection<Salesperson> Salespersons
        {
            get { return _salespersons; }
            set { SetProperty(ref _salespersons, value); }
        }

        private ObservableCollection<Sale> _sales;
        public ObservableCollection<Sale> Sales
        {
            get { return _sales; }
            set { SetProperty(ref _sales, value); }
        }

        //Display

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
            Salespersons = new ObservableCollection<Salesperson>(_salespersonServ.SearchSalespersons(_key, _currentPage));
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
            Salespersons = new ObservableCollection<Salesperson>(_salespersonServ.SearchSalespersons(_key, _currentPage));
        }

        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete
                    ?? (_delete = new RelayCommand(DeleteMethod));
            }
        }
        private async void DeleteMethod()
        {
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا المندوب؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                _salespersonServ.DeleteSalesperson(_selectedSalesperson);
                Load();
            }
        }

        // Add 

        private RelayCommand _showAdd;
        public RelayCommand ShowAdd
        {
            get
            {
                return _showAdd
                    ?? (_showAdd = new RelayCommand(ShowAddMethod));
            }
        }
        private async void ShowAddMethod()
        {
            NewSalesperson = new Salesperson();
            _salespersonAddDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_salespersonAddDialog);
        }

        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(
                    ExecuteSaveAsync,
                    CanExecuteSave));
            }
        }
        private async void ExecuteSaveAsync()
        {
            if (_salespersonServ.GetSalesperson(_newSalesperson.Name) != null)
            {
                await _currentWindow.ShowMessageAsync("فشل الإضافة", "هذا المندوب موجود مسبقاً", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
            }
            else
            {
                _salespersonServ.AddSalesperson(_newSalesperson);
                _salespersonsSuggestions.Add(_newSalesperson.Name);
                NewSalesperson = new Salesperson();
                await _currentWindow.ShowMessageAsync("نجاح الإضافة", "تم الإضافة بنجاح", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
            }
        }
        private bool CanExecuteSave()
        {
            return !NewSalesperson.HasErrors;
        }

        //
        private RelayCommand _showUpdate;
        public RelayCommand ShowUpdate
        {
            get
            {
                return _showUpdate
                    ?? (_showUpdate = new RelayCommand(ShowUpdateMethod));
            }
        }
        private async void ShowUpdateMethod()
        {
            _salespersonUpdateDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_salespersonUpdateDialog);
        }

        private RelayCommand _update;
        public RelayCommand Update
        {
            get
            {
                return _update ?? (_update = new RelayCommand(
                    ExecuteUpdateAsync,
                    CanExecuteUpdate));
            }
        }
        private async void ExecuteUpdateAsync()
        {
            _salespersonServ.UpdateSalesperson(_selectedSalesperson);
            await _currentWindow.HideMetroDialogAsync(_salespersonUpdateDialog);
            Load();
        }
        private bool CanExecuteUpdate()
        {
            try
            {
                return !SelectedSalesperson.HasErrors && !HasErrors;
            }
            catch
            {
                return false;
            }
        }

        // Show Account

        private RelayCommand _showAccount;
        public RelayCommand ShowAccount
        {
            get
            {
                return _showAccount
                    ?? (_showAccount = new RelayCommand(ShowAccountMethod));
            }
        }
        private async void ShowAccountMethod()
        {
            DateFrom = _saleServ.GetFirstDate(_selectedSalesperson.ID);
            DateTo = _saleServ.GetLastDate(_selectedSalesperson.ID);
            TotalBillPrice = _saleServ.GetTotalBillPrice(_selectedSalesperson.ID, _dateFrom, _dateTo);
            GetSalespersonAccountsMethod();
            _salespersonAccountShowDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_salespersonAccountShowDialog);
        }

        private RelayCommand _getSalespersonAccounts;
        public RelayCommand GetSalespersonAccounts
        {
            get
            {
                return _getSalespersonAccounts
                    ?? (_getSalespersonAccounts = new RelayCommand(GetSalespersonAccountsMethod));
            }
        }
        private void GetSalespersonAccountsMethod()
        {
            Sales = new ObservableCollection<Sale>(_saleServ.GetSalespersonAccounts(_selectedSalesperson.ID, _dateFrom, _dateTo));
            TotalBillPrice = _saleServ.GetTotalBillPrice(_selectedSalesperson.ID, _dateFrom, _dateTo);
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
                case "Add":
                    await _currentWindow.HideMetroDialogAsync(_salespersonAddDialog);
                    Load();
                    break;
                case "Update":
                    await _currentWindow.HideMetroDialogAsync(_salespersonUpdateDialog);
                    Load();
                    break;
                case "AccountShow":
                    await _currentWindow.HideMetroDialogAsync(_salespersonAccountShowDialog);
                    break;
                default:
                    break;
            }

        }


    }
}
