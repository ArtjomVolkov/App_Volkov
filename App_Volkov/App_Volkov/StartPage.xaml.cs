using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Volkov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        List<ContentPage> contentPages = new List<ContentPage>() { new Horoskop(),new Aiaplaan(),new My_project() };
        List<string> tekstid = new List<string> { "Horoskop","Aiaplaan","My projekt" };
        public StartPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Beige,
            };
            for (int i = 0; i < contentPages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.Black,
                    TextColor = Color.White,
                };
                button.Clicked += Navig_fun;
                st.Children.Add(button);
            }
            Content = st;
        }

        private async void Navig_fun(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            await Navigation.PushAsync(contentPages[b.TabIndex]);
        }
    }
}