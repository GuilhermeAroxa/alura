using System;
using System.ComponentModel;
using System.Windows.Input;
using alura.Models;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class DetalhesViewModel : INotifyPropertyChanged
    {
        public Veiculo Veiculo { get; set; }

        public bool TemFreioABS
        {
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemRadio
        {
            get
            {
                return Veiculo.TemRadio;
            }
            set
            {
                Veiculo.TemRadio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public bool TemAr
        {
            get
            {
                return Veiculo.TemAr;
            }
            set
            {
                Veiculo.TemAr = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }
        }
        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }

        }
        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - {0}", Veiculo.FREIOABS);
            }
        }
        public string TextoRadio
        {
            get
            {
                return string.Format("Radio - {0}", Veiculo.RADIO);
            }
        }
        public string TextoAr
        {
            get
            {
                return string.Format("Ar Condicionado - {0}", Veiculo.AR);
            }
        }

        public DetalhesViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ProximoCommand { get; set; }
    }
}
