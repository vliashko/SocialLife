using SL.XamarinRealize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SL.XamarinRealize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();  
        }     
        protected async override void OnAppearing()
        {
            await App.DatabaseE.CreateTable();
            eventsList.ItemsSource = await App.DatabaseE.GetItemsAsync();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Event selectedEvent = (Event)e.SelectedItem;
            EventInfoPage infoPage = new EventInfoPage
            {
                BindingContext = selectedEvent
            };
            await Navigation.PushAsync(infoPage);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Event eventP = new Event();
            var addEventPage = new AddEventPage
            {
                BindingContext = eventP
            };
            await Navigation.PushAsync(addEventPage);
        }
    }
}