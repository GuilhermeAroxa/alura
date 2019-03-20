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

        public AgendamentoView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();
            this.viewmodel = new AgendamentoViewModel(veiculo, usuario);
            this.Title = this.viewmodel.Agendamento.Modelo;
            this.BindingContext = this.viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "MostrarAgendamento",
                async msg =>
                {
                    var confirma = await DisplayAlert("Confirmar Agendamento", "Deseja confirmar o agendamento?", "Sim", "Não");

                    if (confirma)
                    {
                        this.viewmodel.SalvarAgendamento();
                    }
                }
            );

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSalvo",
                async msg =>
                {
                    await DisplayAlert("Pronto", "Agendamento salvo com sucesso", "ok");
                    await Navigation.PopToRootAsync();
                }
            );
            MessagingCenter.Subscribe<ArgumentException>(this, "AgendamentoNaoSalvo",
                async msg =>
                {
                    await DisplayAlert("Falha", "Algo deu errado, confira os dados e tente novamente", "ok");
                    await Navigation.PopToRootAsync();
                }
            );

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "MostrarAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSalvo");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "AgendamentoNaoSalvo");
        }
    }
}
