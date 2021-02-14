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
    public class SaleDisplayViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;

        List<Sale> sales;

        SaleServices _saleServ;
        SafeServices _safeServ;
        CategoryServices _categoryServ;
        SaleCategoryServices _saleCategoryServ;
        ClientAccountServices _clientAccountServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = sales.Where(w => (w.ID.ToString() + w.Client.Name + w.Salesperson.Name).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }

        public SaleDisplayViewModel()
        {
            _saleServ = new SaleServices();
            _safeServ = new SafeServices();
            _categoryServ = new CategoryServices();
            _saleCategoryServ = new SaleCategoryServices();
            _clientAccountServ = new ClientAccountServices();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            sales = _saleServ.GetSales();
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

        private Sale _selectedSale;
        public Sale SelectedSale
        {
            get { return _selectedSale; }
            set { SetProperty(ref _selectedSale, value); }
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
            if (_saleServ.IsExistInRecalls(_selectedSale.ID) || !_saleServ.IsLastSale(_selectedSale.ID))
            {
                await _currentWindow.ShowMessageAsync("فشل التعديل", "لا يمكن تعديل هذه الفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
                return;
            }

            SaleUpdateViewModel.ID = _selectedSale.ID;
            _currentWindow.Hide();
            new SaleUpdateWindow().ShowDialog();
            Load();
            _currentWindow.ShowDialog();
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

                if (_saleServ.IsExistInRecalls(_selectedSale.ID) || !_saleServ.IsLastSale(_selectedSale.ID))
                {
                    await _currentWindow.ShowMessageAsync("فشل الحذف", "لا يمكن حذف هذه الفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "موافق",
                        DialogMessageFontSize = 25,
                        DialogTitleFontSize = 30
                    });
                    return;
                }

                _safeServ.DeleteSafe(_selectedSale.RegistrationDate);
                _clientAccountServ.DeleteAccount(_selectedSale.RegistrationDate);
                var saleCategories = _saleCategoryServ.GetSaleCategories(_selectedSale.ID);
                foreach (var item in saleCategories)
                {
                    Category cat = _categoryServ.GetCategory(item.CategoryID);
                    if (cat.Qty + item.Qty != 0)
                        cat.Cost = (item.CostTotal + (cat.Cost * cat.Qty)) / (cat.Qty + item.Qty);
                    cat.Qty = cat.Qty + item.Qty;
                    _categoryServ.UpdateCategory(cat);
                }
                _saleServ.DeleteSale(_selectedSale);
                sales.Remove(_selectedSale);
                Load();
            }
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
            new SaleAddWindow().ShowDialog();
            sales = _saleServ.GetSales();
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
            SaleShowViewModel.ID = _selectedSale.ID;
            _currentWindow.Hide();
            new SaleShowWindow().ShowDialog();
            sales = _saleServ.GetSales();
            Load();
            _currentWindow.ShowDialog();
        }

        private void GetCurrentPage()
        {
            Sales = new ObservableCollection<Sale>(sales.Where(w => (w.ID.ToString() + w.Client.Name + w.Salesperson.Name).Contains(_key)).OrderByDescending(o => o.RegistrationDate).Skip((_currentPage - 1) * 17).Take(17));
        }


    }
}
