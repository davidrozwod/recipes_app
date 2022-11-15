using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            RecipesListView.ItemsSource = await App.Database.GetRecipesAsync();
        }

        private async void OnButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecipe() { BindingContext = new Recipes() });
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ViewRecipe() { BindingContext = e.SelectedItem as Recipes });
            }
        }
    }
}
