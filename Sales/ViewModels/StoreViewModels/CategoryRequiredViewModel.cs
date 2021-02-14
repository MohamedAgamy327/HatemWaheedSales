using GalaSoft.MvvmLight.CommandWpf;
using Sales.Helpers;
using Sales.Reports;
using Sales.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Sales.Models;
using System.Collections.Generic;

namespace Sales.ViewModels.StoreViewModels
{
    public class CategoryRequiredViewModel : ValidatableBindableBase
    {
        CategoryServices _categoryServ;
        List<CategoryVM> categories;

        private void Load()
        {
            CurrentPage = 1;
            ISFirst = false;
            TotalRecords = categories.Where(w => (w.Company + w.Category + w.Stock).Contains(_key)).Count();
            LastPage = (int)Math.Ceiling(Convert.ToDecimal((double)TotalRecords / 17));
            if (_lastPage == 0)
                LastPage = 1;
            if (_lastPage == 1)
                ISLast = false;
            else
                ISLast = true;
            GetCurrentPage();
        }
        public CategoryRequiredViewModel()
        {
            _categoryServ = new CategoryServices();

            _key = "";
            _isFocused = true;
            categories = _categoryServ.GetRequiredCategories();
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

        private ObservableCollection<CategoryVM> _categories;
        public ObservableCollection<CategoryVM> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
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
            ds.RequiredCategory.Rows.Clear();
            int i = 0;
            foreach (var item in categories.Where(w => w.RequiredQty > 0))
            {
                ds.RequiredCategory.Rows.Add();
                ds.RequiredCategory[i]["Serial"] = i + 1;
                ds.RequiredCategory[i]["Category"] = item.Category + " " + item.Company;
                ds.RequiredCategory[i]["Required"] = item.RequiredQty;
                i++;
            }
            ReportWindow rpt = new ReportWindow();
            RequiredCategoryReport requiredCategoryRPT = new RequiredCategoryReport();
            requiredCategoryRPT.SetDataSource(ds.Tables["RequiredCategory"]);
            rpt.crv.ViewerCore.ReportSource = requiredCategoryRPT;
            Mouse.OverrideCursor = null;
            rpt.ShowDialog();

            //requiredCategoryRPT.PrintOptions.PrinterName = _selectedPrinter;
            //requiredCategoryRPT.PrintToPrinter(1, true, 0, 0);
        }

        private void GetCurrentPage()
        {
            Categories = new ObservableCollection<CategoryVM>(categories.Where(w => (w.Company + w.Category + w.Stock).Contains(_key)).Skip((_currentPage - 1) * 17).Take(17));
        }
    }
}

