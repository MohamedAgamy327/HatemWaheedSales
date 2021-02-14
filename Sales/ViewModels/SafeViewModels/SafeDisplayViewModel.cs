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
    public class SafeDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly SafeAddDialog _safeAddDialog;

        List<Safe> safes;

        SafeServices _safeServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = safes.Where(w => w.Statement.Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal(TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }

        public SafeDisplayViewModel()
        {      
            _safeServ = new SafeServices();
            _safeAddDialog = new SafeAddDialog();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _statementSuggestions = _safeServ.GetStatementSuggetions();      
            safes = _safeServ.GetSafes();
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

        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                SetProperty(ref _key, value);
            }
        }

        private Safe _selectedSafe;
        public Safe SelectedSafe
        {
            get { return _selectedSafe; }
            set { SetProperty(ref _selectedSafe, value); }
        }

        private Safe _newSafe;
        public Safe NewSafe
        {
            get { return _newSafe; }
            set { SetProperty(ref _newSafe, value); }
        }

        private List<string> _statementSuggestions;
        public List<string> StatementSuggestions
        {
            get { return _statementSuggestions; }
            set { SetProperty(ref _statementSuggestions, value); }
        }

        private ObservableCollection<Safe> _safes;
        public ObservableCollection<Safe> Safes
        {
            get { return _safes; }
            set { SetProperty(ref _safes, value); }
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
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا السند؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                _safeServ.DeleteSafe(_selectedSafe);
                safes.Remove(_selectedSafe);
                Load();
            }
        }

        //Add

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
            NewSafe = new Safe();
            NewSafe.Date = DateTime.Now;
            _safeAddDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_safeAddDialog);
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
            if (NewSafe.Statement == null || NewSafe.Amount == null)
                return;
            _newSafe.RegistrationDate = DateTime.Now;
            _newSafe.CanDelete = true;
            _newSafe.Source = 1;
            _safeServ.AddSafe(_newSafe);
            safes.Add(_safeServ.GetLastSafe());
            _statementSuggestions.Add(_newSafe.Statement);
            NewSafe = new Safe();
            NewSafe.Date = DateTime.Now;
            await _currentWindow.ShowMessageAsync("نجاح الإضافة", "تم الإضافة بنجاح", MessageDialogStyle.Affirmative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
        }
        private bool CanExecuteSave()
        {
            return !NewSafe.HasErrors;
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
                    await _currentWindow.HideMetroDialogAsync(_safeAddDialog);
                    Load();
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
