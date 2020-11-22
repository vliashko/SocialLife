using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SL.XamarinRealize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageItemPage : ContentPage
    {
        public ImageItemPage()
        {
            InitializeComponent();
        }
        private void Back(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}