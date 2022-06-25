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
        private const string Endpoint = "https://b217-223-205-224-244.ap.ngrok.io";
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
                if (addPointCount == 0)
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
            updatePoints();
            Device.BeginInvokeOnMainThread(async () =>
            {
                moveCountLabel.Text = moveCount.ToString();
                pointLabel.Text = point.ToString();
            });
        }

        private async void AddPoint()
        {
            var serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var body = new AddWalletRequest { Nounce = Guid.NewGuid().ToString(), Points = 1, WalletAddress = walletId };
            string json = JsonSerializer.Serialize(body, serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync($"{Endpoint}/api/wallet", content);
            updatePoints();
        }
        private async void updatePoints()
        {
            var rsp = await httpClient.GetAsync($"{Endpoint}/api/wallet/{walletId}");
            var rspText = await rsp.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetPointResponse>(rspText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (null != result)
            {
                point = result.Points;
            }
        }
    }

    public class GetPointResponse
    {
        public string Nounce { get; set; }
        public string WalletAddress { get; set; }
        public int Points { get; set; }
    }

    public class AddWalletRequest
    {
        public string Nounce { get; set; }
        public int Points { get; set; }
        public string WalletAddress { get; set; }

    }
}