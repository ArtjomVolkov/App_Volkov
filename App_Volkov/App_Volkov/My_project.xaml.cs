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

namespace App_Volkov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My_project : ContentPage
    {
        private bool isPlankSelected;
        private bool isTimerRunning;
        private bool shouldStopTimer;

        public My_project()
        {
            InitializeComponent();
        }

        private void OnPlankClicked(object sender, EventArgs e)
        {
            isPlankSelected = true;
            TitleLabel.Text = "Выберите время таймера:";
            ExerciseImage.IsVisible = false;
            PlankImage.IsVisible = true;
        }

        private void OnExerciseClicked(object sender, EventArgs e)
        {
            isPlankSelected = false;
            TitleLabel.Text = "Выберите время таймера:";
            PlankImage.IsVisible = false;
            ExerciseImage.IsVisible = true;
        }

        private async void PlaySound()
        {
            await TextToSpeech.SpeakAsync("Таймер окончен");
            // Воспроизвести музыку
        }

        private void OnTimer1Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(30);
            StartTimer(duration);
        }

        private void OnTimer2Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromMinutes(1);
            StartTimer(duration);
        }

        private void OnTimer3Clicked(object sender, EventArgs e)
        {
            var duration = TimeSpan.FromMinutes(2);
            StartTimer(duration);
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
                    PlaySound();

                    isTimerRunning = false;
                    return false; // остановить таймер
                }

                return true; // продолжить таймер
            });
        }
        private void OnStopTimerClicked(object sender, EventArgs e)
        {
            shouldStopTimer = true;
        }
    }
}