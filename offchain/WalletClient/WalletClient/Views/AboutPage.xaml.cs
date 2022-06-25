using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WalletClient.Views
{
    public partial class AboutPage : ContentPage
    {
        private Timer timer;
        private HttpClient httpClient;

        private string walletId = string.Empty;
        private int moveCount;
        private int point;

        public AboutPage()
        {
            InitializeComponent();

            UpdateDisplay();

            var addPointCount = 10;
            timer = new Timer { Interval = 1000 };
            timer.Elapsed += (s, e) =>
            {
                moveCount++;
                UpdateDisplay();

                addPointCount--;
                if(addPointCount == 0)
                {
                    AddPoint();
                    addPointCount = 10;
                }
            };

            httpClient = new HttpClient();

            submitBtn.Clicked += (s, e) =>
            {
                walletId = walletIdEntry.Text;
                var isWalletExist = !string.IsNullOrWhiteSpace(walletId);

                if (isWalletExist)
                {
                    InputMode.IsVisible = false;
                    WalletDetailMode.IsVisible = true;

                    walletIdLabel.Text = walletId;
                    timer.Start();
                }

            };

        }

        private void UpdateDisplay()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                moveCountLabel.Text = moveCount.ToString();
                pointLabel.Text = point.ToString();
            });
        }

        private async void AddPoint()
        {
            var serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var body = new AddWalletRequest { Nounce = "abcd", Points = 1, WalletAddress = walletId };

            string json = JsonSerializer.Serialize(body, serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync("http://localhost:8100/#/api/wallet", content);
        }
    }

    public class AddWalletRequest
    {
        public string Nounce { get; set; }
        public int Points { get; set; }
        public string WalletAddress { get; set; }

    }
}