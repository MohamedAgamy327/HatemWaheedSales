using Sales.ViewModels;
using System.Windows.Controls;

namespace Sales.Views.StoreViews
{
    public partial class StockUserControl : UserControl
    {
        public StockUserControl()
        {
            InitializeComponent();
            Unloaded += (s, e) => ViewModelLocator.Cleanup("Stock");
        }
    }
}
