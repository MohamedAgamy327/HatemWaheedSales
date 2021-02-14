using Sales.Helpers;
using System;
using Sales.Services;
using System.Collections.ObjectModel;
using Sales.Models;
using GalaSoft.MvvmLight.CommandWpf;
using Sales.Views.SupplyViews;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace Sales.ViewModels.SupplyViewModels
{
    public class SupplyDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;

        List<Supply> supplies;

        SafeServices _safeServ;
        SupplyServices _supplyServ;
        CategoryServices _categoryServ;
        ClientAccountServices _clientAccountServ;
        SupplyCategoryServices _supplyCategoryServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = supplies.Where(w => (w.ID.ToString() + w.Client.Name).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }

        public SupplyDisplayViewModel()
        {
            _safeServ = new SafeServices();
            _supplyServ = new SupplyServices();
            _categoryServ = new CategoryServices();
            _clientAccountServ = new ClientAccountServices();
            _supplyCategoryServ = new SupplyCategoryServices();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            supplies = _supplyServ.GetSupplies();
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

        private string _visibility;
        public string Visibility
        {
            get { return _visibility; }
            set { SetProperty(ref _visibility, value); }
        }

        private Supply _selectedSupply;
        public Supply SelectedSupply
        {
            get { return _selectedSupply; }
            set { SetProperty(ref _selectedSupply, value); }
        }

        private ObservableCollection<Supply> _supplies;
        public ObservableCollection<Supply> Supplies
        {
            get { return _supplies; }
            set { SetProperty(ref _supplies, value); }
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
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذه الفاتورة؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                if (_supplyServ.IsExistInRecalls(_selectedSupply.ID) || ! _supplyServ.IsLastSupply(_selectedSupply.ID))
                {
                    await _currentWindow.ShowMessageAsync("فشل الحذف", "لا يمكن حذف هذه الفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "موافق",
                        DialogMessageFontSize = 25,
                        DialogTitleFontSize = 30
                    });
                    return;
                }

                _safeServ.DeleteSafe(_selectedSupply.RegistrationDate);
                _clientAccountServ.DeleteAccount(_selectedSupply.RegistrationDate);
                var supplyCategories = _supplyCategoryServ.GetSupplyCategories(_selectedSupply.ID);
                foreach (var item in supplyCategories)
                {
                    Category cat = _categoryServ.GetCategory(item.CategoryID);
                    if (cat.Qty - item.Qty != 0)
                        cat.Cost = ((cat.Cost * cat.Qty) - item.CostTotal) / (cat.Qty - item.Qty);
                    cat.Qty = cat.Qty - item.Qty;
                    _categoryServ.UpdateCategory(cat);
                }
                _supplyServ.DeleteSupply(_selectedSupply);
                supplies.Remove(_selectedSupply);
                Load();
            }
        }

        // Update Bill

        private RelayCommand _edit;
        public RelayCommand Edit
        {
            get
            {
                return _edit
                    ?? (_edit = new RelayCommand(EditMethod));
            }
        }
        private async void EditMethod()
        {
            if (_supplyServ.IsExistInRecalls(_selectedSupply.ID) || !_supplyServ.IsLastSupply(_selectedSupply.ID))
            {
                await _currentWindow.ShowMessageAsync("فشل التعديل", "لا يمكن تعديل هذه الفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
                return;
            }

            SupplyUpdateViewModel.ID = _selectedSupply.ID;
            _currentWindow.Hide();
            new SupplyUpdateWindow().ShowDialog();
            Load();
            _currentWindow.ShowDialog();
        }

        // Add Bill

        private RelayCommand _showAdd;
        public RelayCommand ShowAdd
        {
            get
            {
                return _showAdd
                    ?? (_showAdd = new RelayCommand(ShowAddMethod));
            }
        }
        private void ShowAddMethod()
        {
            _currentWindow.Hide();
            new SupplyAddWindow().ShowDialog();
            Load();
            _currentWindow.ShowDialog();
        }

        // Show Bill

        private RelayCommand _showDetials;
        public RelayCommand ShowDetials
        {
            get
            {
                return _showDetials
                    ?? (_showDetials = new RelayCommand(ShowDetialsMethod));
            }
        }
        private void ShowDetialsMethod()
        {
            SupplyShowViewModel.ID = _selectedSupply.ID;
            _currentWindow.Hide();
            new SupplyShowWindow().ShowDialog();
            Load();
            _currentWindow.ShowDialog();
        }


        private void GetCurrentPage()
        {
            Supplies = new ObservableCollection<Supply>(supplies.Where(w => (w.ID.ToString() + w.Client.Name).Contains(_key)).OrderByDescending(o => o.RegistrationDate).Skip((_currentPage - 1) * 17).Take(17));
        }

    }
}
