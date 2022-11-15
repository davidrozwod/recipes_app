using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace RecipesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRecipe : ContentPage
    {
        public ViewRecipe()
        {
            InitializeComponent();
        }

        private async void OnButtonClick(object sender, EventArgs e)
        {
            var personItem = (Recipes)BindingContext;
            await Navigation.PushAsync(new EditRecipe() {BindingContext = personItem });
        }



    }
}