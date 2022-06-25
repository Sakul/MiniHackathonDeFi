using System.ComponentModel;
using WalletClient.ViewModels;
using Xamarin.Forms;

namespace WalletClient.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}