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
        List<string> taskNames = new List<string> { "Подъем", "Завтрак", "Уборка", "Спорт", "Работа", "Обед", "Прогулка", "Ужин", "Отдых", "Чтение", "Душ", "Сон" };
        List<string> descriptions = new List<string>
        {
            "Проснуться в 8:00 утра",
            "Приготовить омлет с помидорами",
            "Прибраться в комнате и вынести мусор",
            "Сходить в тренажерный зал на 1 час",
            "Закончить отчет для руководства",
            "Пообедать в столовой компании коллег",
            "Пройтись по парку и посмотреть достопримечательности",
            "Приготовить куриные котлеты с овощами",
            "Посмотреть любимый сериал на Netflix",
            "Прочитать главу из новой книги",
            "Принять освежающий душ",
            "Лечь спать в 23:00"
        };

        public Aiaplaan()
        {
            InitializeComponent();

            tasks = new List<Task>();

            for (int i = 0; i <= 11; i++)
            {
                tasks.Add(new Task
                {
                    Image = $"img{i}.jpg",
                    Taska = taskNames[i],
                    Time = new System.TimeSpan(8 + i, 0, 0),
                    Completed = 0,
                    Description = descriptions[i]
                });
            }

            myListView.ItemsSource = tasks;
            myListView.ItemTapped += ListViewItem;
        }

        private void SaveTasks_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Tasks"] = Newtonsoft.Json.JsonConvert.SerializeObject(tasks);
        }
        private async void ListViewItem(object sender, ItemTappedEventArgs e)
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