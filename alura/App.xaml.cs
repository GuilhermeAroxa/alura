using System;
using System.Diagnostics;
using alura.Models;
using alura.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace alura
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();

            MessagingCenter.Subscribe<Usuario>(this, "LoginSucesso",
            (usuario) =>
            {
                //MainPage = new NavigationPage(new ListagemView());
                MainPage = new MasterDetailView(usuario);
            });
        }

        protected override void OnStart()
        {
            // Handle when your app start
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
