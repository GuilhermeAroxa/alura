using System;
using System.Windows.Input;
using alura.Models;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }
        public string Nome { get { return Agendamento.Nome; } set { Agendamento.Nome = value; } }
        public string Fone { get { return Agendamento.Fone; } set { Agendamento.Fone = value; } }
        public string Email { get { return Agendamento.Email; } set { Agendamento.Email = value; } }
        public TimeSpan HoraAgendamento { get { return Agendamento.HoraAgendamento; } set { Agendamento.HoraAgendamento = value; } }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            AgendamentoCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "MostrarAgendamento");
            });
        }

        public ICommand AgendamentoCommand { get; set;  }
    }
}
