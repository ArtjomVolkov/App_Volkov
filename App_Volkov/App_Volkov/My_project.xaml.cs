using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms.PlatformConfiguration;


namespace App_Volkov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My_project : ContentPage
    {
        public bool isPlankSelected;
        public bool isTimerRunning;
        private bool shouldStopTimer;

        public My_project()
        {
            InitializeComponent();
        }

        private void PlankClicked(object sender, EventArgs e)
        {
            isPlankSelected = true;
            TitleLabel.IsVisible= true;
            TitleLabel.Text = "Выберите время таймера:";
            ExerciseImage.IsVisible = false;
            PlankImage.IsVisible = true;
            Timer1Button.IsVisible = true;
            Timer2Button.IsVisible = true;
            Timer3Button.IsVisible = true;
            Timer1Button.IsEnabled = true;
            Timer2Button.IsEnabled = true;
            Timer3Button.IsEnabled = true;
        }

        private void ExerciseClicked(object sender, EventArgs e)
        {
            isPlankSelected = false;
            TitleLabel.IsVisible = true;
            TitleLabel.Text = "Выберите время таймера:";
            PlankImage.IsVisible = false;
            ExerciseImage.IsVisible = true;
            Timer1Button.IsVisible = true;
            Timer2Button.IsVisible = true;
            Timer3Button.IsVisible = true;
            Timer1Button.IsEnabled = true;
            Timer2Button.IsEnabled = true;
            Timer3Button.IsEnabled = true;
        }

        /*private async void PlaySound()
        {
            await TextToSpeech.SpeakAsync("Таймер окончен");
            
        }*/

        private void OnTimer1Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(30);
            StartTimer(duration);
            Timer1Button.IsEnabled = false;
            Timer2Button.IsEnabled = false;
            Timer3Button.IsEnabled = false;
            Stop.IsVisible = true;
            ExerciseButton.IsEnabled = false;
            PlankButton.IsEnabled = false;
        }

        private void OnTimer2Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromMinutes(1);
            StartTimer(duration);
            Timer1Button.IsEnabled = false;
            Timer2Button.IsEnabled = false;
            Timer3Button.IsEnabled = false;
            Stop.IsVisible = true;
            ExerciseButton.IsEnabled = false;
            PlankButton.IsEnabled = false;
        }

        private void OnTimer3Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromMinutes(2);
            StartTimer(duration);
            Timer1Button.IsEnabled = false;
            Timer2Button.IsEnabled = false;
            Timer3Button.IsEnabled = false;
            Stop.IsVisible = true;
            ExerciseButton.IsEnabled = false;
            PlankButton.IsEnabled = false;
        }

        private void StartTimer(TimeSpan duration)
        {
            isTimerRunning = true;
            shouldStopTimer = false;

            TitleLabel.Text = duration.ToString(@"mm\:ss");

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (shouldStopTimer)
                {
                    isTimerRunning = false;
                    return false; // остановить таймер
                }

                duration = duration.Subtract(TimeSpan.FromSeconds(1));
                TitleLabel.Text = duration.ToString(@"mm\:ss");

                if (duration == TimeSpan.Zero)
                {
                    TitleLabel.Text = "Таймер окончен";
                    Stop.Text = "Начать заново.";
                    try
                    {
                        Vibration.Vibrate();
                        var a = TimeSpan.FromSeconds(5);
                        Vibration.Vibrate(a);
                    }
                    catch (Exception) { }

                    isTimerRunning = false;
                    return false; // остановить таймер
                }

                return true; // продолжить таймер
            });
        }
        private void OnStopTimerClicked(object sender, EventArgs e)
        {
            shouldStopTimer = true;
            Stop.IsVisible = false;
            Timer1Button.IsVisible= false;
            Timer2Button.IsVisible = false;
            Timer3Button.IsVisible = false;
            PlankImage.IsVisible= false;
            ExerciseImage.IsVisible = false;
            TitleLabel.IsVisible= false;
            ExerciseButton.IsEnabled = true;
            PlankButton.IsEnabled = true;
        }
    }
}