using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.SaleViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Sales.ViewModels.SaleViewModels
{
    public class SaleUpdateViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly CategoriesShowDialog _categoriesDialog;

        SafeServices _safeServ;
        SaleServices _saleServ;
        ClientServices _clientServ;
        CategoryServices _categoryServ;
        SalespersonServices _salespersonServ;
        SaleCategoryServices _saleCategoryServ;
        ClientAccountServices _clientAccountServ;

        public static int ID
        {
            get; set;
        }

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)_categoryServ.GetCategoriesNumer(_key) / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            Categories = new ObservableCollection<Category>(_categoryServ.SearchCategories(_key, _currentPage));
        }

        public SaleUpdateViewModel()
        {
            _safeServ = new SafeServices();
            _saleServ = new SaleServices();
            _clientServ = new ClientServices();
            _categoryServ = new CategoryServices();
            _salespersonServ = new SalespersonServices();
            _saleCategoryServ = new SaleCategoryServices();
            _clientAccountServ = new ClientAccountServices();
            _categoriesDialog = new CategoriesShowDialog();
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();

            _key = "";
            _isFocused = true;
            _selectedSale = _saleServ.GetSale(ID);
            Salespersons = new ObservableCollection<Salesperson>(_salespersonServ.GetSalespersons());
            _saleCategories = new ObservableCollection<SaleCategoryVM>(_saleCategoryServ.GetSaleCategoriesVM(ID));
            Report = "تقرير الفاتورة";
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

        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                SetProperty(ref _key, value);
            }
        }

        private string _report;
        public string Report
        {
            get { return _report; }
            set { SetProperty(ref _report, value); }
        }

        private Sale _selectedSale;
        public Sale SelectedSale
        {
            get { return _selectedSale; }
            set { SetProperty(ref _selectedSale, value); }
        }

        private Salesperson _selectedSalesperson;
        public Salesperson SelectedSalesperson
        {
            get { return _selectedSalesperson; }
            set { SetProperty(ref _selectedSalesperson, value); }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }

        private SaleCategoryVM _newSaleCategory;
        public SaleCategoryVM NewSaleCategory
        {
            get { return _newSaleCategory; }
            set { SetProperty(ref _newSaleCategory, value); }
        }

        private SaleCategoryVM _selectedSaleCategory;
        public SaleCategoryVM SelectedSaleCategory
        {
            get { return _selectedSaleCategory; }
            set { SetProperty(ref _selectedSaleCategory, value); }
        }

        private SaleCategory _selectedOldPrice;
        public SaleCategory SelectedOldPrice
        {
            get { return _selectedOldPrice; }
            set { SetProperty(ref _selectedOldPrice, value); }
        }

        private ObservableCollection<Salesperson> _salespersons;
        public ObservableCollection<Salesperson> Salespersons
        {
            get { return _salespersons; }
            set { SetProperty(ref _salespersons, value); }
        }

        private ObservableCollection<SaleCategoryVM> _saleCategories;
        public ObservableCollection<SaleCategoryVM> SaleCategories
        {
            get { return _saleCategories; }
            set { SetProperty(ref _saleCategories, value); }
        }

        private ObservableCollection<SaleCategory> _oldPrices;
        public ObservableCollection<SaleCategory> OldPrices
        {
            get { return _oldPrices; }
            set { SetProperty(ref _oldPrices, value); }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        // Bill

        private RelayCommand _selectPrice;
        public RelayCommand SelectPrice
        {
            get
            {
                return _selectPrice ?? (_selectPrice = new RelayCommand(
                    ExecuteSelectPrice));
            }
        }
        private void ExecuteSelectPrice()
        {
            try
            {
                if (SelectedOldPrice == null)
                    return;
                NewSaleCategory.Price = _selectedOldPrice.Price;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }

        private RelayCommand _addToBill;
        public RelayCommand AddToBill
        {
            get
            {
                return _addToBill
                    ?? (_addToBill = new RelayCommand(ExecuteAddToBillAsync, CanExecuteAddToBill));
            }
        }
        private async void ExecuteAddToBillAsync()
        {
            try
            {
                if (NewSaleCategory.Price == null || NewSaleCategory.Qty == null || NewSaleCategory.Category == null)
                    return;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                };
                //if (_saleCategories.SingleOrDefault(s => s.CategoryID == _newSaleCategory.CategoryID) != null)
                //{
                //    MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذا الصنف موجود مسبقاً فى الفاتورة", MessageDialogStyle.Affirmative, mySettings);
                //    return;
                //}
                if (_newSaleCategory.Qty > _selectedCategory.Qty + _saleCategoryServ.GetCategoryQty(ID, _newSaleCategory.CategoryID))
                {
                    MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذه الكمية غير متوفرة فى المخزن", MessageDialogStyle.Affirmative, mySettings);
                    return;
                }
                _saleCategories.Add(_newSaleCategory);
                NewSaleCategory = new SaleCategoryVM();
                SelectedSale.Cost = SaleCategories.Sum(s => s.CostTotal);
                SelectedSale.Price = SaleCategories.Sum(s => s.PriceTotal);
                OldPrices = new ObservableCollection<SaleCategory>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
        private bool CanExecuteAddToBill()
        {
            try
            {
                return NewSaleCategory != null ? !NewSaleCategory.HasErrors : false;
            }
            catch
            {
                return false;
            }
        }

        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete
                    ?? (_delete = new RelayCommand(DeleteMethodAsync));
            }
        }
        private async void DeleteMethodAsync()
        {
            try
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
                    _saleCategories.Remove(_selectedSaleCategory);
                    SelectedSale.Cost = SaleCategories.Sum(s => s.CostTotal);
                    SelectedSale.Price = SaleCategories.Sum(s => s.PriceTotal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
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
        private void EditMethod()
        {
            try
            {
                NewSaleCategory = SelectedSaleCategory;
                _saleCategories.Remove(_selectedSaleCategory);
                _selectedCategory = _categoryServ.GetCategory(_newSaleCategory.CategoryID);
                SelectedSale.Cost = SaleCategories.Sum(s => s.CostTotal);
                SelectedSale.Price = SaleCategories.Sum(s => s.PriceTotal);
                OldPrices = new ObservableCollection<SaleCategory>(_saleCategoryServ.GetOldPrices(_newSaleCategory.CategoryID, _selectedSale.ClientID));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          }

        private RelayCommand _showReport;
        public RelayCommand ShowReport
        {
            get
            {
                return _showReport ?? (_showReport = new RelayCommand(
                    ExecuteShowReport));
            }
        }
        private void ExecuteShowReport()
        {
            try
            {
                if (SelectedSale.Cost != null && SelectedSale.Cost != 0)
                    Report = Math.Round(Convert.ToDecimal(SelectedSale.Price - SelectedSale.Cost), 2) + " جنيهاً";
                else
                    Report = "لا يوجد أصناف فى الفاتورة";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        private RelayCommand _hideReport;
        public RelayCommand HideReport
        {
            get
            {
                return _hideReport ?? (_hideReport = new RelayCommand(
                    ExecuteHideReport));
            }
        }
        private void ExecuteHideReport()
        {
            Report = "تقرير الفاتورة";
        }

        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(
                    ExecuteSave,
                    CanExecuteSave));
            }
        }
        private void ExecuteSave()
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                _selectedSale.Salesperson = SelectedSalesperson;
                _saleServ.UpdateSale(_selectedSale);
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
                _saleCategoryServ.DeleteSaleCategories(ID);
                foreach (var item in _saleCategories)
                {
                    SaleCategory _saleCategory = new SaleCategory
                    {
                        CategoryID = item.CategoryID,
                        Cost = item.Cost,
                        CostTotal = item.CostTotal,
                        Price = item.Price,
                        PriceTotal = item.PriceTotal,
                        SaleID = ID,
                        Qty = item.Qty
                    };
                    _saleCategoryServ.AddSaleCategory(_saleCategory);
                    Category cat = _categoryServ.GetCategory(item.CategoryID);
                    cat.Qty = cat.Qty - item.Qty;
                    _categoryServ.UpdateCategory(cat);
                }

                ClientAccount _account = new ClientAccount
                {
                    ClientID = _selectedSale.ClientID,
                    Date = _selectedSale.Date,
                    RegistrationDate = _selectedSale.RegistrationDate,
                    Statement = "فاتورة مبيعات رقم " + ID,
                    Credit = _selectedSale.CashPaid + _selectedSale.DiscountPaid,
                    Debit = _selectedSale.Price
                };
                _clientAccountServ.AddAccount(_account);

                if (_selectedSale.CashPaid > 0)
                {
                    Safe _safe = new Safe
                    {
                        Date = _selectedSale.Date,
                        RegistrationDate = _selectedSale.RegistrationDate,
                        Statement = "فاتورة مبيعات رقم " + ID + " للعميل: " + _selectedSale.Client.Name,
                        Amount = _selectedSale.CashPaid,
                        Source = 4
                    };
                    _safeServ.AddSafe(_safe);
                }
                Mouse.OverrideCursor = null;
                _currentWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanExecuteSave()
        {
            try
            {
                if (SelectedSale.HasErrors || SelectedSalesperson == null)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        //Categories

        private RelayCommand _browseCategories;
        public RelayCommand BrowseCategories
        {
            get
            {
                return _browseCategories ?? (_browseCategories = new RelayCommand(
                    ExecuteBrowseCategoriesAsync));
            }
        }
        private async void ExecuteBrowseCategoriesAsync()
        {
            OldPrices = new ObservableCollection<SaleCategory>();
            NewSaleCategory = new SaleCategoryVM();
            Key = "";
            Load();
            _categoriesDialog.DataContext = this;
            await _currentWindow.ShowMetroDialogAsync(_categoriesDialog);
        }

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
            Categories = new ObservableCollection<Category>(_categoryServ.SearchCategories(_key, _currentPage));
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
            Categories = new ObservableCollection<Category>(_categoryServ.SearchCategories(_key, _currentPage));
        }

        private RelayCommand _selectCategory;
        public RelayCommand SelectCategory
        {
            get
            {
                return _selectCategory
                    ?? (_selectCategory = new RelayCommand(ExecuteSelectCategoryAsync));
            }
        }
        private async void ExecuteSelectCategoryAsync()
        {
            try
            {
                if (SelectedCategory == null)
                    return;
                NewSaleCategory.Category = SelectedCategory.Name;
                NewSaleCategory.CategoryID = SelectedCategory.ID;
                NewSaleCategory.Company = SelectedCategory.Company.Name;
                NewSaleCategory.Cost = SelectedCategory.Cost;
                NewSaleCategory.Price = SelectedCategory.Price;
                await _currentWindow.HideMetroDialogAsync(_categoriesDialog);
                OldPrices = new ObservableCollection<SaleCategory>(_saleCategoryServ.GetOldPrices(_newSaleCategory.CategoryID, _selectedSale.ClientID));
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
                case "Categories":
                    await _currentWindow.HideMetroDialogAsync(_categoriesDialog);
                    Load();
                    break;
                default:
                    break;
            }

        }
    }
}
