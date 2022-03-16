using GymApp.Helpers;
using GymApp.Model;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        public int Count = 1;

        AddExercisesItemData exercises = new AddExercisesItemData();

        public ObservableCollection<Exercises> Items { get; set; }

        int ID;

        public CategoryViewModel _vm;

        public CategoryView(int id)
        {
            

            ID = id;

            Items = new ObservableCollection<Exercises>();

            foreach (Exercises a in exercises.ExercisesItems)
            {
                if (a.CategoryID == ID)
                {
                    if(a.ExercisesID == Count)
                    {
                        Items.Add(a);
                    }
                }
            }

            
            InitializeComponent();
            BindingContext = this;
            SomeCollection.ItemsSource = Items;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Items.Clear();
            Count++;
            foreach (Exercises a in exercises.ExercisesItems)
            {
                if (a.CategoryID == ID)
                {
                    if (a.ExercisesID == Count)
                    {
                        Items.Add(a);
                    }
                    if(Count == 7)
                    {
                        DisplayAlert("Все упражнения выполнены", "Нажмите 'ОК' чтобы продолжить", "ОК");

                        Navigation.PopModalAsync();
                    }
                }
            }
        }
    }
}