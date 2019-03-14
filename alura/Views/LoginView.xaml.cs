using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace alura.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "LoginFalha",
                exce =>
                {
                    DisplayAlert("Falha no Login", exce.Message, "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "LoginFalha");
        }
    }
}
