using System;
using WalletClient.Services;
using WalletClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WalletClient
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
