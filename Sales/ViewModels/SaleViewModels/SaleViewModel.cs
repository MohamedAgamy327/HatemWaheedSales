using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Sales.Helpers;

namespace Sales.ViewModels.SaleViewModels
{
    public class SaleViewModel : ValidatableBindableBase
    {
        public SaleViewModel()
        {
            _currentViewModel = new SaleDisplayViewModel();
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private RelayCommand<string> _navigateToView;
        public RelayCommand<string> NavigateToView
        {
            get
            {
                return _navigateToView
                    ?? (_navigateToView = new RelayCommand<string>(NavigateToViewMethod));
            }
        }
        private void NavigateToViewMethod(string destination)
        {
            switch (destination)
            {
                case "SaleDisplay":
                    CurrentViewModel = new SaleDisplayViewModel();
                    break;
                case "SalespersonDisplay":
                    CurrentViewModel = new SalespersonDisplayViewModel();
                    break;
                case "SaleReport":
                    CurrentViewModel = new SaleReportViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
