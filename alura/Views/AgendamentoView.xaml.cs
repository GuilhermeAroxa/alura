using System;
using System.Collections.Generic;
using alura.Models;
using alura.ViewModels;
using Xamarin.Forms;

namespace alura.Views
{
    public partial class AgendamentoView : ContentPage
    {
        AgendamentoViewModel viewmodel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.viewmodel = new AgendamentoViewModel(veiculo);
            this.Title = this.viewmodel.Agendamento.Veiculo.Nome;
            this.BindingContext = this.viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "MostrarAgendamento",
                msg =>
                {
                    DisplayAlert("Agendamento",
            string.Format(
            @"Veículo: {0}
Nome: {1}
Fone: {2}
E-mail: {3}
Data Agendamento: {4}
Hora Agendamento:{5}",
            this.viewmodel.Agendamento.Veiculo.Nome, this.viewmodel.Agendamento.Nome, this.viewmodel.Agendamento.Fone, this.viewmodel.Agendamento.Email, this.viewmodel.Agendamento.DataAgendamento.ToString("dd/MM/yyy"), this.viewmodel.Agendamento.HoraAgendamento), "OK");
                });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "MostrarAgendamento");
        }
    }
}
