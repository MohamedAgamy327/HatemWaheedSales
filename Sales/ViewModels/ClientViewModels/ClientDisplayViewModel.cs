using MahApps.Metro.Controls;
using Sales.Helpers;
using Sales.Views.ClientViews;
using Sales.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Sales.Models;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls.Dialogs;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Sales.Reports;

namespace Sales.ViewModels.ClientViewModels
{
    public class ClientDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly ClientAddDialog _clientAddDialog;
        private readonly ClientInfoDialog _clientInfoDialog;
        private readonly ClientUpdateDialog _clientUpdateDialog;
        private readonly ClientAccountShowDialog _clientAccountShowDialog;

        ClientServices _clientServ;
        CategoryServices _categoryServ;
        ClientInfoServices _clientInfoServ;
        ClientAccountServices _accountServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = _clientServ.GetClientsNumer(Key);
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)_clientServ.GetClientsNumer(_key) / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            Clients = new ObservableCollection<Client>(_clientServ.SearchClients(_key, _currentPage));
        }

        public ClientDisplayViewModel()
        {
            _clientServ = new ClientServices();
            _categoryServ = new CategoryServices();
            _clientInfoServ = new ClientInfoServices();
            _accountServ = new ClientAccountServices();
            _clientAddDialog = new ClientAddDialog();
            _clientInfoDialog = new ClientInfoDialog();
            _clientUpdateDialog = new ClientUpdateDialog();
            _clientAccountShowDialog = new ClientAccountShowDialog();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _categories = new ObservableCollection<CategoryVM>(_categoryServ.GetCategories());
            _namesSuggestions = _clientServ.GetNamesSuggetions();
            _addressSuggestions = _clientServ.GetAddressSuggetions();
            Load();
        }

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetProperty(ref _isFocused, value); }
        }

        private bool _canEdit;
        public bool CanEdit
        {
            get { return _canEdit; }
            set { SetProperty(ref _canEdit, value); }
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

        private bool _accountStartType;
        public bool AccountStartType
        {
            get { return _accountStartType; }
            set { SetProperty(ref _accountStartType, value); }
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

        private decimal? _accountStart;
        [Required(ErrorMessage = "رصيد بداية المدة مطلوب")]
        public decimal? AccountStart
        {
            get { return _accountStart; }
            set { SetProperty(ref _accountStart, value); }
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

        private string _isDiscount;
        public string IsDiscount
        {
            get { return _isDiscount; }
            set { SetProperty(ref _isDiscount, value); }
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

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { SetProperty(ref _selectedClient, value); }
        }

        private ClientInfoVM _selectedClientCategory;
        public ClientInfoVM SelectedClientCategory
        {
            get { return _selectedClientCategory; }
            set { SetProperty(ref _selectedClientCategory, value); }
        }

        private Client _newClient;
        public Client NewClient
        {
            get { return _newClient; }
            set { SetProperty(ref _newClient, value); }
        }

        private ClientInfo _newClientInfo;
        public ClientInfo NewClientInfo
        {
            get { return _newClientInfo; }
            set { SetProperty(ref _newClientInfo, value); }
        }

        private ClientAccountVM _selectedClientAccount;
        public ClientAccountVM SelectedClientAccount
        {
            get { return _selectedClientAccount; }
            set { SetProperty(ref _selectedClientAccount, value); }
        }

        private CategoryVM _selectedCategory;
        public CategoryVM SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }

        private List<string> _namesSuggestions ;
        public List<string> NamesSuggestions
        {
            get { return _namesSuggestions; }
            set { SetProperty(ref _namesSuggestions, value); }
        }

        private List<string> _addressSuggestions;
        public List<string> AddressSuggestions
        {
            get { return _addressSuggestions; }
            set { SetProperty(ref _addressSuggestions, value); }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetProperty(ref _clients, value); }
        }

        private ObservableCollection<ClientInfoVM> _clientCategories;
        public ObservableCollection<ClientInfoVM> ClientCategories
        {
            get { return _clientCategories; }
            set { SetProperty(ref _clientCategories, value); }
        }

        private ObservableCollection<CategoryVM> _categories;
        public ObservableCollection<CategoryVM> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private ObservableCollection<ClientAccount> _clientAccounts;
        public ObservableCollection<ClientAccount> ClientAccounts
        {
            get { return _clientAccounts; }
            set
            {
                SetProperty(ref _clientAccounts, value);
                OnPropertyChanged("DuringAccount");
                OnPropertyChanged("NotDuringAccount");
            }
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
            Clients = new ObservableCollection<Client>(_clientServ.SearchClients(_key, _currentPage));
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
            Clients = new ObservableCollection<Client>(_clientServ.SearchClients(_key, _currentPage));
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
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا العميل؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                _clientServ.DeleteClient(_selectedClient);
                Load();
            }
        }

        // Add Client

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
            NewClient = new Client();
            AccountStart = null;
            _clientAddDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_clientAddDialog);
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
            if (AccountStart == null || NewClient.Name == null)
                return;

            if (_clientServ.GetClient(_newClient.Name) != null)
            {
                await _currentWindow.ShowMessageAsync("فشل الإضافة", "هذاالعميل موجود مسبقاً", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
            }
            else
            {
                if (_accountStartType == true)
                    _newClient.AccountStart = _accountStart;
                else
                    _newClient.AccountStart = -_accountStart;
                _clientServ.AddClient(_newClient);
                _namesSuggestions.Add(_newClient.Name);
                _addressSuggestions.Add(_newClient.Address);
                NewClient = new Client();
                AccountStart = null;
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
            return !NewClient.HasErrors && !HasErrors;
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
            DateFrom = _accountServ.GetFirstDate(_selectedClient.ID);
            DateTo = _accountServ.GetLastDate(_selectedClient.ID);
            GetClientAccountsMethod();
            _clientAccountShowDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_clientAccountShowDialog);
        }

        private RelayCommand _getClientAccounts;
        public RelayCommand GetClientAccounts
        {
            get
            {
                return _getClientAccounts
                    ?? (_getClientAccounts = new RelayCommand(GetClientAccountsMethod));
            }
        }
        private void GetClientAccountsMethod()
        {
            SelectedClientAccount = _accountServ.GetAccountInfo(_selectedClient.ID, _dateFrom, _dateTo);
            ClientAccounts = new ObservableCollection<ClientAccount>(_accountServ.GetClientAccounts(_selectedClient.ID, _dateFrom, _dateTo));
        }

        private RelayCommand _print;
        public RelayCommand Print
        {
            get
            {
                return _print
                    ?? (_print = new RelayCommand(PrintMethod));
            }
        }
        private void PrintMethod()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            DS ds = new DS();
            ds.ClientAccount.Rows.Clear();
            int i = 0;
            foreach (var item in _clientAccounts)
            {
                ds.ClientAccount.Rows.Add();
                ds.ClientAccount[i]["Serial"] = i + 1;
                ds.ClientAccount[i]["Client"] = _selectedClient.Name;
                ds.ClientAccount[i]["DateFrom"] = _dateFrom;
                ds.ClientAccount[i]["DateTo"] = _dateTo;
                ds.ClientAccount[i]["Date"] = item.Date;
                ds.ClientAccount[i]["Statement"] = item.Statement;
                ds.ClientAccount[i]["Debit"] = item.Debit;
                ds.ClientAccount[i]["Credit"] = item.Credit;
                ds.ClientAccount[i]["TotalDebit"] = _selectedClientAccount.TotalDebit;
                ds.ClientAccount[i]["TotalCredit"] = _selectedClientAccount.TotalCredit;
                ds.ClientAccount[i]["DuringAccount"] = Math.Abs(Convert.ToDecimal(_selectedClientAccount.DuringAccount));
                if (_selectedClientAccount.DuringAccount > 0)
                    ds.ClientAccount[i]["DuringAccountType"] = "له";
                else if (_selectedClientAccount.DuringAccount < 0)
                    ds.ClientAccount[i]["DuringAccountType"] = "عليه";
                ds.ClientAccount[i]["NotDuringAccount"] = Math.Abs(Convert.ToDecimal(_selectedClientAccount.OldAccount));
                if (_selectedClientAccount.OldAccount > 0)
                    ds.ClientAccount[i]["NotDuringAccountType"] = "له";
                else if (_selectedClientAccount.OldAccount < 0)
                    ds.ClientAccount[i]["NotDuringAccountType"] = "عليه";
                ds.ClientAccount[i]["CurrentAccount"] = Math.Abs(Convert.ToDecimal(_selectedClientAccount.CurrentAccount));
                if (_selectedClientAccount.CurrentAccount > 0)
                    ds.ClientAccount[i]["CurrentAccountType"] = "له";
                else if (_selectedClientAccount.CurrentAccount < 0)
                    ds.ClientAccount[i]["CurrentAccountType"] = "عليه";
                i++;
            }
            ReportWindow rpt = new ReportWindow();
            ClientAccountReport accountClientRPT = new ClientAccountReport();
            accountClientRPT.SetDataSource(ds.Tables["ClientAccount"]);
            rpt.crv.ViewerCore.ReportSource = accountClientRPT;
            Mouse.OverrideCursor = null;
            rpt.ShowDialog();
        }

        // Update Account

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
            if (_selectedClient.ClientAccounts.Count > 0)
                CanEdit = false;
            else
                CanEdit = true;
            AccountStart = Math.Abs(Convert.ToDecimal(_selectedClient.AccountStart));
            if (_selectedClient.AccountStart > 0)
                AccountStartType = true;
            else
                AccountStartType = false;
            _clientUpdateDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_clientUpdateDialog);
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
            if (AccountStart == null)
                return;

            if (_accountStartType == true)
                _selectedClient.AccountStart = _accountStart;
            else
                _selectedClient.AccountStart = -_accountStart;
            _clientServ.UpdateClient(_selectedClient);
            _namesSuggestions.Add(_selectedClient.Name);
            await _currentWindow.HideMetroDialogAsync(_clientUpdateDialog);
            Load();
        }
        private bool CanExecuteUpdate()
        {
            try
            {
                return !SelectedClient.HasErrors && !HasErrors;
            }
            catch
            {
                return false;
            }
        }

        // Client Info

        private RelayCommand _showClientInfo;
        public RelayCommand ShowClientInfo
        {
            get
            {
                return _showClientInfo
                    ?? (_showClientInfo = new RelayCommand(ShowClientInfoMethod));
            }
        }
        private async void ShowClientInfoMethod()
        {
            NewClientInfo = new ClientInfo();
            ClientCategories = new ObservableCollection<ClientInfoVM>(_clientInfoServ.GetClientInfoCategories(_selectedClient.ID));
            _clientInfoDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_clientInfoDialog);
        }

        private RelayCommand _addClientInfo;
        public RelayCommand AddClientInfo
        {
            get
            {
                return _addClientInfo ?? (_addClientInfo = new RelayCommand(
                    ExecuteAddClientInfo,
                    CanExecuteAddClientInfo));
            }
        }
        private void ExecuteAddClientInfo()
        {
            try
            {
                if (SelectedCategory == null)
                    return;
                //if (_clientInfoServ.GetClientInfo(_selectedClient.ID, _selectedCategory.ID) != null)
                //{
                //    MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذا الصنف موجود مسبقاً ", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                //    {
                //        AffirmativeButtonText = "موافق",
                //        DialogMessageFontSize = 25,
                //        DialogTitleFontSize = 30
                //    });
                //    return;
                //}
                _newClientInfo.ClientID = _selectedClient.ID;
                _clientInfoServ.AddClientInfo(_newClientInfo);
                ClientCategories = new ObservableCollection<ClientInfoVM>(_clientInfoServ.GetClientInfoCategories(_selectedClient.ID));
                NewClientInfo = new ClientInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }
        private bool CanExecuteAddClientInfo()
        {
            return !NewClientInfo.HasErrors;
        }

        private RelayCommand _deleteClientInfo;
        public RelayCommand DeleteClientInfo
        {
            get
            {
                return _deleteClientInfo
                    ?? (_deleteClientInfo = new RelayCommand(DeleteClientInfoMethod));
            }
        }
        private async void DeleteClientInfoMethod()
        {
            try
            {
                MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا ؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    NegativeButtonText = "الغاء",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
                if (result == MessageDialogResult.Affirmative)
                {
                    _clientInfoServ.DeleteClientInfo(_selectedClientCategory.ClientID, _selectedClientCategory.CategoryID);
                    ClientCategories = new ObservableCollection<ClientInfoVM>(_clientInfoServ.GetClientInfoCategories(_selectedClient.ID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                case "ClientInfo":
                    await _currentWindow.HideMetroDialogAsync(_clientInfoDialog);
                    break;
                case "Add":
                    await _currentWindow.HideMetroDialogAsync(_clientAddDialog);
                    Load();
                    break;
                case "Update":
                    await _currentWindow.HideMetroDialogAsync(_clientUpdateDialog);
                    Load();
                    break;
                case "AccountShow":
                    await _currentWindow.HideMetroDialogAsync(_clientAccountShowDialog);
                    break;
                default:
                    break;
            }

        }
    }
}
