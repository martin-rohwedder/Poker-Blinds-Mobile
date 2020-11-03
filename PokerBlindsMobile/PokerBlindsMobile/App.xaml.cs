using PokerBlindsMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokerBlindsMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PlayPokerPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
