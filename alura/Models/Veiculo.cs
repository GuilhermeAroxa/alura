using System;
namespace alura.Models
{
    public class Veiculo
    {
        public const int FREIOABS = 1000;
        public const int RADIO = 2000;
        public const int AR = 3000;
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
        public bool TemFreioABS { get; set; }
        public bool TemRadio { get; set; }
        public bool TemAr { get; set; }
        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}", Preco + (TemFreioABS ? FREIOABS : 0) + (TemRadio ? RADIO : 0) + (TemAr ? AR : 0));
            }
        }
    }
}
