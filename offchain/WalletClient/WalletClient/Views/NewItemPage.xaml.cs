using System;
using System.Collections.Generic;
using System.ComponentModel;
using WalletClient.Models;
using WalletClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WalletClient.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}