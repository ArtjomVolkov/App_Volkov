using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace App_Volkov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Horoskop : ContentPage
    {
        // Создание словаря гороскопов и описаний
        Dictionary<string, string> horoscope = new Dictionary<string, string>//(StringComparer.OrdinalIgnoreCase)
        {
            {"Водолей", "21 января - 19 февраля.\nВы независимый и непринужденный мыслитель."},
            {"Рыбы", "20 февраля - 20 марта.\nВы сострадательная и творческая душа."},
            {"Овен", "21 марта - 20 апреля.\nВы прирожденный лидер и рождены брать на себя ответственность."},
            {"Телец", "21 апреля - 21 мая.\nВы надежный и сильный, с любовью к красоте."},
            {"Близнецы", "22 мая - 21 июня.\nВы любознательный и адаптивный коммуникатор."},
            {"Рак", "22 июня - 22 июля.\nВы заботливый и интуитивный, с сильной эмоциональной стороной."},
            {"Лев", "23 июля - 23 августа.\nВы уверены в себе и театральны, у вас талант к драматургии"},
            {"Дева", "24 августа - 23 сентября.\nВы практичны и ориентированы на детали, любите порядок"},
            {"Весы", " 24 сентября - 23 октября.\nВы очаровательны и дипломатичны, любите красоту и гармонию"},
            {"Скорпион", "24 октября - 22 ноября.\nВы энергичны и страстны, с глубоким эмоциональная глубина."},
            {"Стрелец", "23 ноября - 21 декабря.\nТы предприимчивый и независимый, с любовью к свободе."},
            {"Козерог", "22 декабря - 20 января.\nТы дисциплинированный и трудолюбивый, со стремлением к успеху."}
        };
        // Создание словаря гороскопов и изображений
        Dictionary<string, string> horoscopeImg = new Dictionary<string, string>
        {
            {"Водолей", "vodoley.png"},
            {"Рыбы", "ribi.png"},
            {"Овен", "oven.png"},
            {"Телец", "telew.png"},
            {"Близнецы", "bliznew.png"},
            {"Рак", "rak.png"},
            {"Лев", "lev.png"},
            {"Дева", "deva.png"},
            {"Весы", "vesi.png"},
            {"Скорпион", "skorp.png"},
            {"Стрелец", "strelew.png"},
            {"Козерог", "kozerog.png"}
        };
        public List<string> HoroscopeNames { get; set; }

        public Horoskop()
        {
            InitializeComponent();
            // Создаем список названий гороскопов из ключей словаря horoscope
            HoroscopeNames = new List<string>(horoscope.Keys);
            horoscopeListView.ItemsSource = HoroscopeNames;
        }

        private void HoroscopeDate(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            // Получаем месяц и день из выбранной даты
            int month = selectedDate.Month;
            int day = selectedDate.Day;
            // Получаем название гороскопа
            string horoscopeName = Horoscope(month, day);

            horoscopeDescriptionEditor.Text = horoscope[horoscopeName];
            horoscopeImage.Source = horoscope[horoscopeName];
        }

        private void HoroscopeNameEntry(object sender, TextChangedEventArgs e)
        {
            string horoscopeName = e.NewTextValue;

            if (horoscope.ContainsKey(horoscopeName))
            {
                horoscopeDescriptionEditor.Text = horoscope[horoscopeName];
                horoscopeImage.Source = horoscopeImg[horoscopeName];
            }
        }

        private void HoroscopeList(object sender, SelectedItemChangedEventArgs e)
        {
            string horoscopeName = e.SelectedItem as string;
            horoscopeDescriptionEditor.Text = horoscope[horoscopeName];
            horoscopeImage.Source = horoscopeImg[horoscopeName];
        }
        private string Horoscope(int month, int day)
        {

            if (month == 1 && day >= 20 || month == 2 && day <= 18)
            {
                return "Водолей";
            }
            else if (month == 2 && day >= 19 || month == 3 && day <= 20)
            {
                return "Рыбы";
            }
            else if (month == 3 && day >= 21 || month == 4 && day <= 19)
            {
                return "Овен";
            }
            else if (month == 4 && day >= 20 || month == 5 && day <= 20)
            {
                return "Телец";
            }
            else if (month == 5 && day >= 21 || month == 6 && day <= 20)
            {
                return "Близнецы";
            }
            else if (month == 6 && day >= 21 || month == 7 && day <= 22)
            {
                return "Рак";
            }
            else if (month == 7 && day >= 23 || month == 8 && day <= 22)
            {
                return "Лев";
            }
            else if (month == 8 && day >= 23 || month == 9 && day <= 22)
            {
                return "Дева";
            }
            else if (month == 9 && day >= 23 || month == 10 && day <= 23)
            {
                return "Весы";
            }
            else if (month == 10 && day >= 24 || month == 11 && day <= 22)
            {
                return "Скорпион";
            }
            else if (month == 11 && day >= 23 || month == 12 && day <= 21)
            {
                return "Стрелец";
            }
            else if (month == 12 && day >= 22 || month == 1 && day <= 19)
            {
                return "Козерог";
            }
            else
            {
                throw new Exception("Неверная дата...");
            }
        }
    }
}