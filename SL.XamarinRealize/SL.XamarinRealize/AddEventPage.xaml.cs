using SL.XamarinRealize.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SL.XamarinRealize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEventPage : ContentPage
    {
        public AddEventPage()
        {
            InitializeComponent();
        }
        private async void SaveEvent(object sender, EventArgs e)
        {
            var eventP = (Event)BindingContext;
            if (!String.IsNullOrEmpty(eventP.Naming))
            {
                await App.DatabaseE.SaveItemAsync(eventP);
            }
            await this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}