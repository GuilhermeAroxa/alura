using System;
using System.ComponentModel;
using System.Windows.Input;
using alura.Models;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class DetalhesViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }

        public bool TemFreioABS
        {
            get => Veiculo.TemFreioABS;
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemRadio
        {
            get => Veiculo.TemRadio;
            set
            {
                Veiculo.TemRadio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public bool TemAr
        {
            get => Veiculo.TemAr;
            set
            {
                Veiculo.TemAr = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public string ValorTotal => Veiculo.PrecoTotalFormatado;
        public string TextoFreioABS => string.Format("Freio ABS - {0}", Veiculo.FREIOABS);
        public string TextoRadio => string.Format("Radio - {0}", Veiculo.RADIO);
        public string TextoAr => string.Format("Ar Condicionado - {0}", Veiculo.AR);

        public ICommand ProximoCommand { get; set; }

        public DetalhesViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }
    }
}
