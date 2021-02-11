using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.StoreViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;


namespace Sales.ViewModels.StoreViewModels
{
    public class CategoryViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly CategoryAddDialog _categoryAddDialog;
        private readonly CategoryUpdateDialog _categoryUpdateDialog;
        private readonly CategoryInformationDialog _categoryInformationDialog;

        List<Category> categories;

        StockServices _stockServ;
        CompanyServices _companyServ;
        CategoryServices _categoryServ;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = categories.Where(w => (w.Name + w.Company.Name + w.Stock.Name).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }

        public CategoryViewModel()
        {
            _stockServ = new StockServices();
            _companyServ = new CompanyServices();
            _categoryServ = new CategoryServices();
            _categoryAddDialog = new CategoryAddDialog();
            _categoryUpdateDialog = new CategoryUpdateDialog();
            _categoryInformationDialog = new CategoryInformationDialog();

            _key = "";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            categories = _categoryServ.GetCategories();
            _colorsSuggestions = categories.Select(s => s.Color).Distinct().ToList();
            Stocks = new ObservableCollection<Stock>(_stockServ.GetStocks());
            Companies = new ObservableCollection<Company>(_companyServ.GetCompanies());

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

        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set { SetProperty(ref _selectedCompany, value); }
        }

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set { SetProperty(ref _selectedStock, value); }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }

        private CategoryVM _selectedCategoryInformation;
        public CategoryVM SelectedCategoryInformation
        {
            get { return _selectedCategoryInformation; }
            set { SetProperty(ref _selectedCategoryInformation, value); }
        }

        private Category _newCategory;
        public Category NewCategory
        {
            get { return _newCategory; }
            set { SetProperty(ref _newCategory, value); }
        }

        private List<string> _colorsSuggestions;
        public List<string> ColorsSuggestions
        {
            get { return _colorsSuggestions; }
            set { SetProperty(ref _colorsSuggestions, value); }
        }

        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { SetProperty(ref _companies, value); }
        }

        private ObservableCollection<Stock> _stocks;
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set { SetProperty(ref _stocks, value); }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
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
            MessageDialogResult result = await _currentWindow.ShowMessageAsync("تأكيد الحذف", "هل تـريــد حــذف هـذا الصنف؟", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                NegativeButtonText = "الغاء",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
            if (result == MessageDialogResult.Affirmative)
            {
                if (_categoryServ.IsExistInSupplies(_selectedCategory.ID) || _categoryServ.IsExistInSales(_selectedCategory.ID))
                {
                    await _currentWindow.ShowMessageAsync("فشل الحذف", "لا يمكن حذف هذا الصنف", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "موافق",
                        DialogMessageFontSize = 25,
                        DialogTitleFontSize = 30
                    });
                    return;
                }
                _categoryServ.DeleteCategory(_selectedCategory);
                categories.Remove(_selectedCategory);
                GetCurrentPage();
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
            NewCategory = new Category();
            _categoryAddDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_categoryAddDialog);
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
            if (SelectedCompany == null || SelectedStock == null || NewCategory.Name == null || NewCategory.QtyStart == null || NewCategory.Price == null || NewCategory.Cost == null || NewCategory.RequestLimit == null)
                return;
            _newCategory.Qty = _newCategory.QtyStart;
            _categoryServ.AddCategory(_newCategory);
            _colorsSuggestions.Add(_newCategory.Color);
            _newCategory.Stock = SelectedStock;
            _newCategory.Company = SelectedCompany;
            categories.Add(_newCategory);
            NewCategory = new Category();
            await _currentWindow.ShowMessageAsync("نجاح الإضافة", "تم الإضافة بنجاح", MessageDialogStyle.Affirmative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
        }
        private bool CanExecuteSave()
        {
            if (NewCategory.HasErrors || SelectedCompany == null)
                return false;
            else
                return true;
        }

        // Update

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
            CanEdit = !(_categoryServ.IsExistInSupplies(_selectedCategory.ID) || _categoryServ.IsExistInSales(_selectedCategory.ID));
            _categoryUpdateDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_categoryUpdateDialog);
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
            if (SelectedCompany == null || SelectedCategory.QtyStart == null || SelectedCategory.Price == null || SelectedCategory.Cost == null || SelectedCategory.RequestLimit == null)
                return;

            if (!(_categoryServ.IsExistInSupplies(_selectedCategory.ID) || _categoryServ.IsExistInSales(_selectedCategory.ID)))
                _selectedCategory.Qty = _selectedCategory.QtyStart;
            _selectedCategory.Stock = SelectedStock;
            _selectedCategory.Company = SelectedCompany;
            _categoryServ.UpdateCategory(_selectedCategory);
            await _currentWindow.HideMetroDialogAsync(_categoryUpdateDialog);
            Load();
        }
        private bool CanExecuteUpdate()
        {
            try
            {
                return SelectedCategory != null ? !SelectedCategory.HasErrors : false;
            }
            catch
            {
                return false;
            }
        }

        // Category Information

        private RelayCommand _showInformation;
        public RelayCommand ShowInformation
        {
            get
            {
                return _showInformation
                    ?? (_showInformation = new RelayCommand(ShowInformationMethod));
            }
        }
        private async void ShowInformationMethod()
        {
            DateFrom = _categoryServ.GetFirstDate(_selectedCategory.ID);
            DateTo = _categoryServ.GetLastDate(_selectedCategory.ID);
            SelectedCategoryInformation = _categoryServ.GetCategoryInformation(_selectedCategory.ID);
            SelectedCategoryInformation = _categoryServ.GetCategoryInformation(SelectedCategoryInformation, _dateFrom, _dateTo);
            _categoryInformationDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_categoryInformationDialog);
        }

        private RelayCommand _getInformation;
        public RelayCommand GetInformation
        {
            get
            {
                return _getInformation
                    ?? (_getInformation = new RelayCommand(GetInformationMethod));
            }
        }
        private void GetInformationMethod()
        {
            SelectedCategoryInformation = _categoryServ.GetCategoryInformation(SelectedCategoryInformation, _dateFrom, _dateTo);
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
                    await _currentWindow.HideMetroDialogAsync(_categoryAddDialog);
                    Load();
                    break;
                case "Update":
                    await _currentWindow.HideMetroDialogAsync(_categoryUpdateDialog);
                    break;
                case "Information":
                    await _currentWindow.HideMetroDialogAsync(_categoryInformationDialog);
                    break;
                default:
                    break;
            }

        }


        private void GetCurrentPage()
        {
            Categories = new ObservableCollection<Category>(categories.Where(w => (w.Name + w.Company.Name + w.Stock.Name).Contains(_key)).OrderBy(o => o.Company.Name).ThenBy(o => o.Name).Skip((_currentPage - 1) * 17).Take(17));
        }

    }
}
