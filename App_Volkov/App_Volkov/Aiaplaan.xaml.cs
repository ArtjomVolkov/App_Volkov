using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Volkov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Aiaplaan : ContentPage
    {
        private List<Note> notes;

        public Aiaplaan()
        {
            InitializeComponent();

            notes = new List<Note>();

            for (int i = 0; i < 12; i++)
            {
                notes.Add(new Note { ImageSource = $"img{i}.jpg", Name = $"Note {i + 1}" });
            }

            listView.ItemsSource = notes;

            listView.ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var note = (Note)e.Item;

            DisplayAlert("Note", $"You tapped {note.Name}", "OK");
        }

        private void OnTimePickerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var timePicker = (TimePicker)sender;

            if (timePicker.BindingContext is Note note)
            {
                var hour = timePicker.Time.Hours;

                note.ImageSource = $"img{hour}.jpg";
                note.Name = $"Note {hour + 1}";

                listView.ItemsSource = null;
                listView.ItemsSource = notes;
            }
        }
        public class Note
        {
            public string ImageSource { get; set; }
            public string Name { get; set; }
        }
    }
}