﻿using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Services;
using Sales.Views.SupplyViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sales.ViewModels.SupplyViewModels
{
    public class SupplyUpdateViewModel : ValidatableBindableBase
    {
        public static int ID
        {
            get; set;
        }

        MetroWindow _currentWindow;
        private readonly CategoriesShowDialog _categoriesDialog;

        SafeServices _safeServ;
        SupplyServices _supplyServ;
        CategoryServices _categoryServ;
        ClientAccountServices _clientAccountServ;
        SupplyCategoryServices _supplyCategoryServ;

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

        public SupplyUpdateViewModel()
        {
            _safeServ = new SafeServices();
            _supplyServ = new SupplyServices();
            _categoryServ = new CategoryServices();
            _clientAccountServ = new ClientAccountServices();
            _supplyCategoryServ = new SupplyCategoryServices();
            _categoriesDialog = new CategoriesShowDialog();

            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _supplyCategories = new ObservableCollection<SupplyCategoryVM>(_supplyCategoryServ.GetSupplyCategoriesVM(ID));
            _selectedSupply = _supplyServ.GetSupply(ID);
        }

        private bool _isFocused = true;
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

        private string _key = "";
        public string Key
        {
            get { return _key; }
            set
            {
                SetProperty(ref _key, value);
            }
        }

        private Supply _selectedSupply;
        public Supply SelectedSupply
        {
            get { return _selectedSupply; }
            set { SetProperty(ref _selectedSupply, value); }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }

        private SupplyCategory _selectedOldCost;
        public SupplyCategory SelectedOldCost
        {
            get { return _selectedOldCost; }
            set { SetProperty(ref _selectedOldCost, value); }
        }

        private SupplyCategoryVM _newSupplyCategory;
        public SupplyCategoryVM NewSupplyCategory
        {
            get { return _newSupplyCategory; }
            set { SetProperty(ref _newSupplyCategory, value); }
        }

        private SupplyCategoryVM _selectedSupplyCategory;
        public SupplyCategoryVM SelectedSupplyCategory
        {
            get { return _selectedSupplyCategory; }
            set { SetProperty(ref _selectedSupplyCategory, value); }
        }

        private ObservableCollection<SupplyCategory> _oldCosts;
        public ObservableCollection<SupplyCategory> OldCosts
        {
            get { return _oldCosts; }
            set { SetProperty(ref _oldCosts, value); }
        }

        private ObservableCollection<SupplyCategoryVM> _supplyCategories;
        public ObservableCollection<SupplyCategoryVM> SupplyCategories
        {
            get { return _supplyCategories; }
            set { SetProperty(ref _supplyCategories, value); }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        // Bill

        private RelayCommand _selectCost;
        public RelayCommand SelectCost
        {
            get
            {
                return _selectCost ?? (_selectCost = new RelayCommand(
                    ExecuteSelectCost));
            }
        }
        private void ExecuteSelectCost()
        {
            try
            {
                if (SelectedOldCost == null)
                    return;
                NewSupplyCategory.Cost = _selectedOldCost.Cost;
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
                if (NewSupplyCategory.Qty == null || NewSupplyCategory.Cost == null || NewSupplyCategory.Category == null || NewSupplyCategory.Price == null)
                    return;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                };
                if (_supplyCategories.SingleOrDefault(s => s.CategoryID == _newSupplyCategory.CategoryID) != null)
                {
                    MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذا الصنف موجود مسبقاً فى الفاتورة", MessageDialogStyle.Affirmative, mySettings);
                    return;
                }
                _supplyCategories.Add(_newSupplyCategory);
                NewSupplyCategory = new SupplyCategoryVM();
                SelectedSupply.Cost = SupplyCategories.Sum(s => s.CostTotal);
                OldCosts = new ObservableCollection<SupplyCategory>();
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
                if (NewSupplyCategory != null)
                    return !NewSupplyCategory.HasErrors;
                else
                    return false;
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
                    _supplyCategories.Remove(_selectedSupplyCategory);
                    SelectedSupply.Cost = SupplyCategories.Sum(s => s.CostTotal);
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
                NewSupplyCategory = SelectedSupplyCategory;
                _supplyCategories.Remove(_selectedSupplyCategory);
                SelectedSupply.Cost = SupplyCategories.Sum(s => s.CostTotal);
                OldCosts = new ObservableCollection<SupplyCategory>(_supplyCategoryServ.GetOldCosts(_newSupplyCategory.CategoryID, _selectedSupply.ClientID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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
                _supplyServ.UpdateSupply(_selectedSupply);
                _safeServ.DeleteSafe(_selectedSupply.RegistrationDate);
                _clientAccountServ.DeleteAccount(_selectedSupply.RegistrationDate);
                var supplyCategories = _supplyCategoryServ.GetSupplyCategories(_selectedSupply.ID);
                foreach (var item in supplyCategories)
                {
                    Category cat = _categoryServ.GetCategory(item.CategoryID);
                    if (cat.Qty - item.Qty != 0)
                        cat.Cost = ((cat.Cost * cat.Qty) - item.CostTotal) / (cat.Qty - item.Qty);
                    if (cat.Cost < 0)
                        cat.Cost = 0;
                    cat.Qty = cat.Qty - item.Qty;
                    _categoryServ.UpdateCategory(cat);
                }
                _supplyCategoryServ.DeleteSupplyCategories(ID);

                foreach (var item in _supplyCategories)
                {
                    SupplyCategory _supplyCategory = new SupplyCategory
                    {
                        CategoryID = item.CategoryID,
                        Cost = item.Cost,
                        CostTotal = item.CostTotal,
                        SupplyID = ID,
                        Qty = item.Qty,
                        Price = item.Price
                    };
                    _supplyCategoryServ.AddSupplyCategory(_supplyCategory);

                    Category cat = _categoryServ.GetCategory(item.CategoryID);
                    if (cat.Qty + item.Qty != 0)
                        cat.Cost = (item.CostTotal + (cat.Cost * cat.Qty)) / (cat.Qty + item.Qty);
                    cat.Qty = cat.Qty + item.Qty;
                    cat.Price = item.Price;
                    _categoryServ.UpdateCategory(cat);
                }


                ClientAccount _account = new ClientAccount
                {
                    ClientID = _selectedSupply.ClientID,
                    Date = _selectedSupply.Date,
                    RegistrationDate = _selectedSupply.RegistrationDate,
                    Statement = "فاتورة مشتريات رقم " + ID,
                    Credit = _selectedSupply.Cost,
                    Debit = _selectedSupply.CashPaid + _selectedSupply.DiscountPaid
                };
                _clientAccountServ.AddAccount(_account);

                if (_selectedSupply.CashPaid > 0)
                {
                    Safe _safe = new Safe
                    {
                        Date = _selectedSupply.Date,
                        RegistrationDate = _selectedSupply.RegistrationDate,
                        Statement = "فاتورة مشتريات رقم " + ID + " من العميل : " + _selectedSupply.Client.Name,
                        Amount = -_selectedSupply.CashPaid,
                        Source = 3
                    };
                    _safeServ.AddSafe(_safe);
                }
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
                if (SelectedSupply.HasErrors)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        // Categories

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
            OldCosts = new ObservableCollection<SupplyCategory>();
            NewSupplyCategory = new SupplyCategoryVM();
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
                NewSupplyCategory.Category = SelectedCategory.Name;
                NewSupplyCategory.CategoryID = SelectedCategory.ID;
                NewSupplyCategory.Company = SelectedCategory.Company.Name;
                NewSupplyCategory.Cost = SelectedCategory.Cost;
                await _currentWindow.HideMetroDialogAsync(_categoriesDialog);
                OldCosts = new ObservableCollection<SupplyCategory>(_supplyCategoryServ.GetOldCosts(_newSupplyCategory.CategoryID, _selectedSupply.ClientID));
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
