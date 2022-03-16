using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GymApp.Services;
using Firebase.Database;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentView
    {
        public Home()
        {
            InitializeComponent();  
        }


        private async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            Category selectLang = e.CurrentSelection[0] as Category;

            await Navigation.PushModalAsync(new CategoryView(selectLang.CategoryID));

        }

    

        
    }
}