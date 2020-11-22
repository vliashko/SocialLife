using SL.XamarinRealize.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SL.XamarinRealize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPage : ContentPage
    {
        public QRPage()
        {
           
            InitializeComponent();
            balance.Text = $"Баланс : {App.Money}";
        }

      
        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
           await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    myCode.Text = result.Text;
                    if(myCode.Text != "")
                    {
                        Random random = new Random();
                        int amountofMoney = random.Next(2, 6);
                        App.Money += amountofMoney;
                        balance.Text = $"Баланс : {App.Money}";
                        myCode.Text = "";
                    }
                });
            };
        }
    }
}