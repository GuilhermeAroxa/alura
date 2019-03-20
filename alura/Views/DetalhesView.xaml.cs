using System;
using System.Collections.Generic;
using alura.Models;
using alura.ViewModels;
using Xamarin.Forms;

namespace alura.Views
{
    public partial class DetalhesView : ContentPage
    {
        public Veiculo Veiculo { get; private set; }
        public Usuario usuario { get; private set; }
        public DetalhesView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.usuario = usuario;
            this.BindingContext = new DetalhesViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo",
            msg =>
            {
                Navigation.PushAsync(new AgendamentoView(msg, this.usuario));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }

    }
}
