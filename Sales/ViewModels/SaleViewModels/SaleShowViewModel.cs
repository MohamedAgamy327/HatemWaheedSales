using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Sales.Helpers;
using Sales.Models;
using Sales.Reports;
using Sales.Services;
using Sales.Views.SaleViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Sales.ViewModels.SaleViewModels
{
    public class SaleShowViewModel : ValidatableBindableBase
    {
        MetroWindow _currentWindow;
        private readonly SaleRecallDialog _saleRecallDialog;

        SaleServices _saleServ;
        CategoryServices _categoryServ;
        SaleRecallServices _saleRecallServ;
        SaleCategoryServices _saleCategoryServ;
        ClientAccountServices _clientAccountServ;

        public static int ID
        {
            get; set;
        }

        public SaleShowViewModel()
        {
        
            _saleServ = new SaleServices();
            _categoryServ = new CategoryServices();
            _saleRecallServ = new SaleRecallServices();
            _saleCategoryServ = new SaleCategoryServices();
            _clientAccountServ = new ClientAccountServices();
            _saleRecallDialog = new SaleRecallDialog();

            _state = "Normal";
            _isFocused = true;
            _currentWindow = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();
            _selectedSale = _saleServ.GetSale(ID);
            _saleCategories = new ObservableCollection<SaleCategoryVM>(_saleCategoryServ.GetSaleCategoriesVM(ID));
            _categories = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleCategoriesVM(ID));
            RecallsQty = _saleRecallServ.GetSaleRecallsSum(ID);
            Report = "تقرير الفاتورة";
        }

        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set { SetProperty(ref _isFocused, value); }
        }

        private decimal? _recallsQty;
        public decimal? RecallsQty
        {
            get { return _recallsQty; }
            set { SetProperty(ref _recallsQty, value); }
        }

        private string _report;
        public string Report
        {
            get { return _report; }
            set { SetProperty(ref _report, value); }
        }

        private string _state ;
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private Sale _selectedSale;
        public Sale SelectedSale
        {
            get { return _selectedSale; }
            set { SetProperty(ref _selectedSale, value); }
        }

        private SaleCategoryVM _selectedSaleCategory;
        public SaleCategoryVM SelectedSaleCategory
        {
            get { return _selectedSaleCategory; }
            set { SetProperty(ref _selectedSaleCategory, value); }
        }

        private SaleRecallVM _newRecall;
        public SaleRecallVM NewRecall
        {
            get { return _newRecall; }
            set { SetProperty(ref _newRecall, value); }
        }

        private SaleRecallVM _selectedRecall;
        public SaleRecallVM SelectedRecall
        {
            get { return _selectedRecall; }
            set { SetProperty(ref _selectedRecall, value); }
        }

        private ObservableCollection<SaleCategoryVM> _saleCategories;
        public ObservableCollection<SaleCategoryVM> SaleCategories
        {
            get { return _saleCategories; }
            set { SetProperty(ref _saleCategories, value); }
        }

        private ObservableCollection<SaleRecallVM> _categories;
        public ObservableCollection<SaleRecallVM> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private ObservableCollection<SaleRecallVM> _saleRecalls;
        public ObservableCollection<SaleRecallVM> SaleRecalls
        {
            get { return _saleRecalls; }
            set { SetProperty(ref _saleRecalls, value); }
        }

        // Show

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
            Report = SelectedSale.Price - SelectedSale.Cost + " جنيهاً";
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

        private RelayCommand<string> _print;
        public RelayCommand<string> Print
        {
            get
            {
                return _print
                    ?? (_print = new RelayCommand<string>(PrintMethod));
            }
        }
        private void PrintMethod(string parameter)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            DS ds = new DS();
            ds.Sale.Rows.Clear();
            int i = 0;
            foreach (var item in _saleCategories)
            {
                ds.Sale.Rows.Add();
                ds.Sale[i]["ID"] = ID;
                ds.Sale[i]["Date"] = _selectedSale.Date;
                ds.Sale[i]["Client"] = _selectedSale.Client.Name;
                ds.Sale[i]["Serial"] = i + 1;
                ds.Sale[i]["Category"] = item.Category + " " + item.Company;
                ds.Sale[i]["Qty"] = item.Qty;
                ds.Sale[i]["Price"] = Math.Round(Convert.ToDecimal(item.Price), 2);
                ds.Sale[i]["TotalPrice"] = Math.Round(Convert.ToDecimal(item.PriceTotal), 2);
                ds.Sale[i]["BillPrice"] = _selectedSale.Price;
                ds.Sale[i]["OldDebt"] = Math.Abs(Convert.ToDecimal(_selectedSale.OldDebt));
                ds.Sale[i]["BillTotal"] = Math.Abs(Convert.ToDecimal(_selectedSale.PriceTotal));
                ds.Sale[i]["Paid"] = _selectedSale.CashPaid;
                ds.Sale[i]["DiscountPaid"] = _selectedSale.DiscountPaid;
                ds.Sale[i]["NewDebt"] = Math.Abs(Convert.ToDecimal(_selectedSale.NewDebt));
                if (_selectedSale.NewDebt > 0)
                    ds.Sale[i]["Type"] = "له";
                else if (_selectedSale.NewDebt < 0)
                    ds.Sale[i]["Type"] = "عليه";

                if (_selectedSale.OldDebt > 0)
                    ds.Sale[i]["Type2"] = "له";
                else if (_selectedSale.OldDebt < 0)
                    ds.Sale[i]["Type2"] = "عليه";
                i++;
            }
            ReportWindow rpt = new ReportWindow();
            if (parameter == "Client")
            {
                SaleReport saleRPT = new SaleReport();
                saleRPT.SetDataSource(ds.Tables["Sale"]);
                rpt.crv.ViewerCore.ReportSource = saleRPT;
                Mouse.OverrideCursor = null;
            }
            else
            {
                SaleReport2 saleRPT = new SaleReport2();
                saleRPT.SetDataSource(ds.Tables["Sale"]);
                rpt.crv.ViewerCore.ReportSource = saleRPT;
                Mouse.OverrideCursor = null;
            }
            _currentWindow.Hide();
            rpt.ShowDialog();
            _currentWindow.ShowDialog();
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
            _saleRecallDialog.DataContext = this;
            State = "Maximized";
            Categories = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleCategoriesVM(ID));
            SaleRecalls = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleRecallsVM(ID));
            await _currentWindow.ShowMetroDialogAsync(_saleRecallDialog);
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
            if (NewRecall.PriceTotal == null)
                return;

            var saleCategoryQty = _saleCategoryServ.GetCategoryQty(ID, _newRecall.CategoryID);
            if (_newRecall.Qty > saleCategoryQty)
            {
                MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", "هذه الكمية اكبر من الكمية الخاصة بالفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
                return;
            }
            var recallQty = _saleRecallServ.GetRecallCategoryQty(ID, _newRecall.CategoryID);
            if (_newRecall.Qty + recallQty > saleCategoryQty)
            {
                MessageDialogResult result = await _currentWindow.ShowMessageAsync("خطأ", " هذه الكمية والمرتجعات اكبر من الكمية الخاصة بالفاتورة", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AffirmativeButtonText = "موافق",
                    DialogMessageFontSize = 25,
                    DialogTitleFontSize = 30
                });
                return;
            }
            DateTime dt = DateTime.Now;
            SaleRecall saleRecall = new SaleRecall
            {
                CategoryID = _newRecall.CategoryID,
                Cost = _newRecall.Cost,
                CostTotal = _newRecall.CostTotal,
                Date = _newRecall.Date,
                Price = _newRecall.Price,
                PriceTotal = _newRecall.PriceTotal,
                RegistrationDate = dt,
                Qty = _newRecall.Qty,
                SaleID = _newRecall.SaleID
            };
            _saleRecallServ.AddSaleRecall(saleRecall);
            Category cat = _categoryServ.GetCategory(_newRecall.CategoryID);
            if (cat.Qty + _newRecall.Qty != 0)
                cat.Cost = (_newRecall.CostTotal + (cat.Cost * cat.Qty)) / (cat.Qty + _newRecall.Qty);
            cat.Qty = cat.Qty + _newRecall.Qty;
            _categoryServ.UpdateCategory(cat);
            ClientAccount _account = new ClientAccount
            {
                ClientID = _selectedSale.ClientID,
                Date = _newRecall.Date,
                RegistrationDate = dt,
                Statement = "مرتجعات فاتورة مبيعات رقم " + ID,
                Credit = _newRecall.PriceTotal,
                Debit = 0
            };
            _clientAccountServ.AddAccount(_account);
            Categories = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleCategoriesVM(ID));
            SaleRecalls = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleRecallsVM(ID));
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
                _saleRecallServ.DeleteSaleRecall(_selectedRecall.RegistrationDate);
                Category cat = _categoryServ.GetCategory(_selectedRecall.CategoryID);
                if (cat.Qty - _selectedRecall.Qty != 0)
                    cat.Cost = ((cat.Cost * cat.Qty) - _selectedRecall.CostTotal) / (cat.Qty - _selectedRecall.Qty);
                cat.Qty = cat.Qty - _selectedRecall.Qty;
                _categoryServ.UpdateCategory(cat);
                SaleRecalls = new ObservableCollection<SaleRecallVM>(_saleRecallServ.GetSaleRecallsVM(ID));
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
                    await _currentWindow.HideMetroDialogAsync(_saleRecallDialog);
                    State = "Normal";
                    RecallsQty = _saleRecallServ.GetSaleRecallsSum(ID);
                    break;
                default:
                    break;
            }

        }
    }
}
