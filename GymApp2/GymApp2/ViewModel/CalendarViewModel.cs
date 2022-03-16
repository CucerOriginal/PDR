using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Model;
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
    class CalendarViewModel
    {
        FirebaseClient client;
        public DateTime dateTime = new DateTime();
        public CalendarViewModel()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            UserKey();
        }

        public async Task<bool> UserKey()
        {
            string key = Preferences.Get("Key", String.Empty);
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Key == key).FirstOrDefault();


            //добавить новую дату
            //await client.Child("Training").PostAsync(new Training() {IdUser = key, Scores = 5, Time = DateTime.Now});

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
        });
    }
}
