using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App_Volkov
{
    public partial class Aiaplaan : ContentPage
    {
        private List<Task> tasks;

        public Aiaplaan()
        {
            InitializeComponent();

            tasks = new List<Task>();

            for (int i = 1; i <= 12; i++)
            {
                tasks.Add(new Task
                {
                    Image = $"img{i}.jpg",
                    Taska = $"Задача {i}",
                    Time = new System.TimeSpan(8 + i, 0, 0),
                    Completed = 0,
                    Description = $"Описание задачи {i}"
                });
            }

            myListView.ItemsSource = tasks;
            myListView.ItemTapped += OnListViewItemTapped;
        }

        private void SaveTasks_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Tasks"] = Newtonsoft.Json.JsonConvert.SerializeObject(tasks);
        }
        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var task = (Task)e.Item;
                await DisplayAlert("Описание задачи", task.Description, "OK");
                myListView.SelectedItem = null;
            }
        }
    }

    public class Task
    {
        public string Image { get; set; }
        public string Taska { get; set; }
        public System.TimeSpan Time { get; set; }
        public int Completed { get; set; }
        public string Description { get; set; }
    }
}