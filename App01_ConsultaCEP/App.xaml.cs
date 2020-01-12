using App01_ConsultaCEP.Interfaces;
using App01_ConsultaCEP.Services;
using Nancy.TinyIoc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ConsultaCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            

            var container = TinyIoCContainer.Current;
            container.Register<IViaCEPService, ViaCEPService>();
            


            MainPage = new MainPage(container.Resolve<IViaCEPService>());


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
