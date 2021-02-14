using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.ClientViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace Sales.ViewModels.ClientViewModels
{
    public class ClientAccountDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly ClientAccountAddDialog _clientAccountAddDialog;

        List<ClientAccount> clientAccounts;

        SafeServices _safeServ;
        ClientServices _clientServ;
        ClientAccountServices _clientAccountServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = clientAccounts.Where(w => (w.Statement + w.Client.Name).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }
        public ClientAccountDisplayViewModel()
        {
            _safeServ = new SafeServices();
            _clientServ = new ClientServices();
            _clientAccountServ = new ClientAccountServices();
            _clientAccountAddDialog = new ClientAccountAddDialog();
            _accountStatements = new ObservableCollection<StatementVM>();

            _key = "";
            _isFocused = true;
            Clients = new ObservableCollection<Client>(_clientServ.GetClients());
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _accountStatements.Add(new StatementVM { ID = 1, Statement = "سند دفع له" });
            _accountStatements.Add(new StatementVM { ID = 2, Statement = "سند قبض منه" });
            _accountStatements.Add(new StatementVM { ID = 5, Statement = "تسوية إضافة له" });
            _accountStatements.Add(new StatementVM { ID = 6, Statement = "تسوية تنزيل منه" });

            clientAccounts = _clientAccountServ.GetAccounts();

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

        private decimal? _amount;
        [Required(ErrorMessage = "المبلغ مطلوب")]
        public decimal? Amount
        {
            get { return _amount; }
            set
            {
                SetProperty(ref _amount, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _oldDebt;
        public decimal? OldDebt
        {
            get { return _oldDebt; }
            set
            {
                SetProperty(ref _oldDebt, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private decimal? _newDebt;
        public decimal? NewDebt
        {
            get
            {
                if (SelectedStatement == null)
                    return _newDebt = null;
                else if (SelectedStatement.Statement == "سند دفع له" || SelectedStatement.Statement == "تسوية تنزيل منه")
                {
                    return _newDebt = OldDebt - Amount;
                }
                else if (SelectedStatement.Statement == "سند قبض منه" || SelectedStatement.Statement == "تسوية إضافة له")
                {
                    return _newDebt = OldDebt + Amount;
                }
                else
                {
                    return _newDebt = null;
                }
            }
            set
            { SetProperty(ref _newDebt, value); }
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

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { SetProperty(ref _selectedClient, value); }
        }

        private ClientAccount _selectedClientAccount;
        public ClientAccount SelectedClientAccount
        {
            get { return _selectedClientAccount; }
            set { SetProperty(ref _selectedClientAccount, value); }
        }

        private StatementVM _selectedstatement;
        public StatementVM SelectedStatement
        {
            get { return _selectedstatement; }
            set
            {
                SetProperty(ref _selectedstatement, value);
                OnPropertyChanged("NewDebt");
            }
        }

        private ClientAccount _newClientAccount;
        public ClientAccount NewClientAccount
        {
            get { return _newClientAccount; }
            set { SetProperty(ref _newClientAccount, value); }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetProperty(ref _clients, value); }
        }

        private ObservableCollection<StatementVM> _accountStatements;
        public ObservableCollection<StatementVM> AccountStatements
        {
            get { return _accountStatements; }
            set { SetProperty(ref _accountStatements, value); }
        }

        private ObservableCollection<ClientAccount> _clientsAccounts;
        public ObservableCollection<ClientAccount> ClientsAccounts
        {
            get { return _clientsAccounts; }
            set { SetProperty(ref _clientsAccounts, value); }
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
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا البند؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                _clientAccountServ.DeleteAccount(_selectedClientAccount);
                _safeServ.DeleteSafe(_selectedClientAccount.RegistrationDate);
                clientAccounts.Remove(_selectedClientAccount);
                GetCurrentPage();
            }
        }

        //Add Account

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
            NewClientAccount = new ClientAccount
            {
                Date = DateTime.Now
            };
            SelectedStatement = null;
            Amount = null;
            _clientAccountAddDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_clientAccountAddDialog);
        }

        private RelayCommand _getclientAccount;
        public RelayCommand GetClientAccount
        {
            get
            {
                return _getclientAccount ?? (_getclientAccount = new RelayCommand(
                   GetClientAccountMethod));
            }
        }
        private void GetClientAccountMethod()
        {
            try
            {
                if (_selectedClient != null)
                    OldDebt = _clientAccountServ.GetClientAccount(_selectedClient.ID) + _selectedClient.AccountStart;
                else
                    OldDebt = null;
            }
            catch
            {
                OldDebt = null;
            }
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
            if (NewDebt == null)
                return;
            DateTime dt = DateTime.Now;
            _newClientAccount.RegistrationDate = dt;
            _newClientAccount.CanDelete = true;
            _newClientAccount.Statement = SelectedStatement.Statement;
            if (_newClientAccount.Statement == "سند دفع له")
            {
                _newClientAccount.Debit = _amount;
                _newClientAccount.Credit = 0;
                Safe safe = new Safe
                {
                    Amount = -_newClientAccount.Debit,
                    Date = _newClientAccount.Date,
                    RegistrationDate = dt,
                    Statement = "سند دفع للعميل : " + _selectedClient.Name,
                    Source = 5
                };
                _safeServ.AddSafe(safe);
            }
            else if (_newClientAccount.Statement == "تسوية تنزيل منه")
            {
                _newClientAccount.Debit = _amount;
                _newClientAccount.Credit = 0;
            }
            else if (_newClientAccount.Statement == "سند قبض منه")
            {
                _newClientAccount.Credit = _amount;
                _newClientAccount.Debit = 0;
                Safe safe = new Safe
                {
                    Amount = _newClientAccount.Credit,
                    Date = _newClientAccount.Date,
                    RegistrationDate = dt,
                    Statement = "سند قبض من العميل : " + _selectedClient.Name,
                    Source = 6
                };
                _safeServ.AddSafe(safe);
            }
            else if (_newClientAccount.Statement == "تسوية إضافة له")
            {
                _newClientAccount.Credit = _amount;
                _newClientAccount.Debit = 0;
            }

            _clientAccountServ.AddAccount(_newClientAccount);
            clientAccounts.Add(_clientAccountServ.GetAccount(_newClientAccount.ID));
            SelectedStatement = null;
            NewClientAccount = new ClientAccount
            {
                Date = DateTime.Now
            };
            Amount = null;
            await _currentWindow.ShowMessageAsync("نجاح الإضافة", "تم الإضافة بنجاح", MessageDialogStyle.Affirmative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
        }
        private bool CanExecuteSave()
        {
            try
            {
                if (NewClientAccount.HasErrors || SelectedClient == null || HasErrors || SelectedStatement == null)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
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
                    await _currentWindow.HideMetroDialogAsync(_clientAccountAddDialog);
                    Load();
                    break;
                default:
                    break;
            }

        }

        // helper methods

        private void GetCurrentPage()
        {
            ClientsAccounts = new ObservableCollection<ClientAccount>(clientAccounts.Where(w => (w.Statement + w.Client.Name).Contains(_key)).OrderByDescending(o => o.RegistrationDate).Skip((_currentPage - 1) * 17).Take(17));
        }

    }
}
