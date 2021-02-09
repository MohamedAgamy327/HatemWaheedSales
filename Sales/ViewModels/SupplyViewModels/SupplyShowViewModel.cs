using GalaSoft.MvvmLight.CommandWpf;
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
    public class SupplyShowViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly SupplyRecallDialog _supplyRecallDialog;

        SupplyServices _supplyServ ;
        CategoryServices _categoryServ ;
        SupplyRecallServices _supplyRecallServ;
        ClientAccountServices _clientAccountServ ;
        SupplyCategoryServices _supplyCategoryServ ;

        public static int ID
        {
            get; set;
        }

        public SupplyShowViewModel()
        {

            _supplyServ = new SupplyServices();
            _categoryServ = new CategoryServices();
            _supplyRecallServ = new SupplyRecallServices();
            _clientAccountServ = new ClientAccountServices();
            _supplyCategoryServ = new SupplyCategoryServices();
            _supplyRecallDialog = new SupplyRecallDialog();

            _state = "Normal";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _selectedSupply = _supplyServ.GetSupply(ID);
            _supplyCategories = new ObservableCollection<SupplyCategoryVM>(_supplyCategoryServ.GetSupplyCategoriesVM(ID));
            _categories = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyCategoriesVM(ID));
            RecallsQty = _supplyRecallServ.GetSupplyRecallsSum(ID);
        }

        private bool _isFocused ;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetProperty(ref _isFocused, value); }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private decimal? _recallsQty;
        public decimal? RecallsQty
        {
            get { return _recallsQty; }
            set { SetProperty(ref _recallsQty, value); }
        }

        private Supply _selectedSupply;
        public Supply SelectedSupply
        {
            get { return _selectedSupply; }
            set { SetProperty(ref _selectedSupply, value); }
        }

        private SupplyCategoryVM _selectedSupplyCategory;
        public SupplyCategoryVM SelectedSupplyCategory
        {
            get { return _selectedSupplyCategory; }
            set { SetProperty(ref _selectedSupplyCategory, value); }
        }

        private SupplyRecallVM _newRecall;
        public SupplyRecallVM NewRecall
        {
            get { return _newRecall; }
            set { SetProperty(ref _newRecall, value); }
        }

        private SupplyRecallVM _selectedRecall;
        public SupplyRecallVM SelectedRecall
        {
            get { return _selectedRecall; }
            set { SetProperty(ref _selectedRecall, value); }
        }

        private ObservableCollection<SupplyCategoryVM> _supplyCategories;
        public ObservableCollection<SupplyCategoryVM> SupplyCategories
        {
            get { return _supplyCategories; }
            set { SetProperty(ref _supplyCategories, value); }
        }

        private ObservableCollection<SupplyRecallVM> _categories;
        public ObservableCollection<SupplyRecallVM> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private ObservableCollection<SupplyRecallVM> _supplyRecalls;
        public ObservableCollection<SupplyRecallVM> SupplyRecalls
        {
            get { return _supplyRecalls; }
            set { SetProperty(ref _supplyRecalls, value); }
        }

        // Recalls

        private RelayCommand _showRecall;
        public RelayCommand ShowRecall
        {
            get
            {
                return _showRecall
                    ?? (_showRecall = new RelayCommand(ShowRecallMethodAsync));
            }
        }
        private async void ShowRecallMethodAsync()
        {
            _supplyRecallDialog.DataContext = this;
            State = "Maximized";
            Categories = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyCategoriesVM(ID));
            SupplyRecalls = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyRecallsVM(ID));
            await _currentWindow.ShowMetroDialogAsync(_supplyRecallDialog);
        }

        private RelayCommand _addRecall;
        public RelayCommand AddRecall
        {
            get
            {
                return _addRecall
                    ?? (_addRecall = new RelayCommand(ExecuteAddRecallAsync, CanExecuteAddRecall));
            }
        }
        private async void ExecuteAddRecallAsync()
        {
            if (NewRecall.Qty == null || NewRecall.Cost == null)
                return;
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            };
            var supplyCategoryQty = _supplyCategoryServ.GetCategoryQty(ID, _newRecall.CategoryID);
            if (_newRecall.Qty > supplyCategoryQty)
            {
                MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذه الكمية اكبر من الكمية الخاصة بالفاتورة", MessageDialogStyle.Affirmative, mySettings);
                return;
            }
            var recallQty = _supplyRecallServ.GetRecallCategoryQty(ID, _newRecall.CategoryID);
            if (_newRecall.Qty + recallQty > supplyCategoryQty)
            {
                MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", " هذه الكمية والمرتجعات اكبر من الكمية الخاصة بالفاتورة", MessageDialogStyle.Affirmative, mySettings);
                return;
            }
            DateTime dt = DateTime.Now;
            SupplyRecall supplyRecall = new SupplyRecall
            {
                CategoryID = _newRecall.CategoryID,
                Cost=_newRecall.Cost,
                CostTotal=_newRecall.CostTotal,
                Date = _newRecall.Date,
                RegistrationDate = dt,
                Qty = _newRecall.Qty,
                SupplyID = _newRecall.SupplyID
            };
            _supplyRecallServ.AddSupplyRecall(supplyRecall);
            Category cat = _categoryServ.GetCategory(_newRecall.CategoryID);
            if (cat.Qty - _newRecall.Qty != 0)
                cat.Cost = ((cat.Cost * cat.Qty) - _newRecall.CostTotal) / (cat.Qty - _newRecall.Qty);
            cat.Qty = cat.Qty - _newRecall.Qty;
            _categoryServ.UpdateCategory(cat);
            ClientAccount _account = new ClientAccount
            {
                ClientID = _selectedSupply.ClientID,
                Date = _newRecall.Date,
                RegistrationDate = dt,
                Statement = "مرتجعات فاتورة مشتريات رقم " + ID,
                Credit = 0,
                Debit = _newRecall.CostTotal
            };
            _clientAccountServ.AddAccount(_account);        
            Categories = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyCategoriesVM(ID));
            SupplyRecalls = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyRecallsVM(ID));
            await _currentWindow.ShowMessageAsync("نجاح الإضافة", "تم الإضافة بنجاح", MessageDialogStyle.Affirmative, new MetroDialogSettings()
            {
                AffirmativeButtonText = "موافق",
                DialogMessageFontSize = 25,
                DialogTitleFontSize = 30
            });
        }
        private bool CanExecuteAddRecall()
        {
            try
            {
                if (NewRecall.HasErrors || NewRecall == null)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private RelayCommand _deleteRecall;
        public RelayCommand DeleteRecall
        {
            get
            {
                return _deleteRecall
                    ?? (_deleteRecall = new RelayCommand(DeleteRecallMethod));
            }
        }
        private async void DeleteRecallMethod()
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
                _clientAccountServ.DeleteAccount(_selectedRecall.RegistrationDate);
                _supplyRecallServ.DeleteSupplyRecall(_selectedRecall.RegistrationDate);
                Category cat = _categoryServ.GetCategory(_selectedRecall.CategoryID);
                if (cat.Qty + _selectedRecall.Qty != 0)
                    cat.Cost = ((cat.Cost * cat.Qty) + _selectedRecall.CostTotal) / (cat.Qty + _selectedRecall.Qty);
                cat.Qty = cat.Qty + _selectedRecall.Qty;
                _categoryServ.UpdateCategory(cat);
                SupplyRecalls = new ObservableCollection<SupplyRecallVM>(_supplyRecallServ.GetSupplyRecallsVM(ID));
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
                case "Recall":
                    await _currentWindow.HideMetroDialogAsync(_supplyRecallDialog);
                    State = "Normal";
                    RecallsQty = _supplyRecallServ.GetSupplyRecallsSum(ID);
                    break;
                default:
                    break;
            }

        }
    }
}
