using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Model;
using GymApp.ViewModels;
using GymApp2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymApp2.ViewModel
{
    class CalendarViewModel : BaseModel
    {
        FirebaseClient client;
        private int score;
        public int Score {
            set
            {
                this.score = value;
                OnPropertyChanged();
            }
            get
            {
                return this.score;
            }
        }

        
        public CalendarViewModel()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            //UserKey(); 
        }

        public async Task<bool> UserKey()
        {
            string key = Preferences.Get("Key", String.Empty);
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Key == key).FirstOrDefault();


            //добавить новую дату
            //DateTime dateTime = DateTime.Now;
            //await client.Child("Training").PostAsync(new Training() { IdUser = key, Scores = 5, Time = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day) });

            return (user != null);
        }
        public async Task<bool> ScoreCount()
        {
            string key = Preferences.Get("Key", String.Empty);

            var user = (await client.Child("Training").OnceAsync<Training>()).Where(u => u.Object.IdUser == key).Where(u => u.Object.Time == SelectedDate).ToList();
            Score = 0;
            foreach (var list in user) 
            {
                Score += list.Object.Scores;
            }

            return (user != null);
        }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => _selectedDate = value;
        }

        public ICommand SelectedDateCommand => new Command<DateTime>((selectedDate) =>
        {
            SelectedDate = selectedDate;
            ScoreCount();
        });

    }
}
