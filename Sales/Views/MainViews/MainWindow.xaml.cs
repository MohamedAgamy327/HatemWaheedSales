using Sales.ViewModels;
using MahApps.Metro.Controls;
using Sales.SplashScreen;
using System.Threading;
using System.ServiceProcess;
using Sales.Models;
using Sales.Services;
using System;

namespace Sales.Views.MainViews
{
    public partial class MainWindow : MetroWindow
    {
        CategoryServices catServ = new CategoryServices();
        SalesDB db = new SalesDB();

        public MainWindow()
        {
            InitializeComponent();

            ServiceController service = new ServiceController("MSSQL$SQLEXPRESS");
            if (service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
            Hide();
            Splasher.Splash = new SplashScreenWindow();
            Splasher.ShowSplash();

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                    MessageListener.Instance.ReceiveMessage(string.Format("Loading " + "{0}" + " %", i));
                Thread.Sleep(40);
            }
            Splasher.CloseSplash();
            //if (DateTime.Now.Date > new DateTime(2018, 4, 8))
            //    Close();
            //else
                Show();
            Closing += (s, e) => ViewModelLocator.Cleanup("Main");
        }
    }
}