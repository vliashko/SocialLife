using SL.XamarinRealize.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SL.XamarinRealize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            await App.DatabaseI.CreateTable();
            itemsList.ItemsSource = await App.DatabaseI.GetItemsAsync();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item selectedItem = (Item)e.SelectedItem;
            ImageItemPage imageItemPage = new ImageItemPage()
            {
                BindingContext = selectedItem
            };
            await Navigation.PushAsync(imageItemPage);
        }
    }
}