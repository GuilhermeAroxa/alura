using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alura.Models;
using alura.ViewModels;
using Xamarin.Forms;

namespace alura.Views
{

    public partial class ListagemView : ContentPage
    {
        public ListagemViewModel viewmodel{ get; set; }
        public ListagemView()
        {
            InitializeComponent();
            this.viewmodel = new ListagemViewModel();
            this.BindingContext = this.viewmodel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "veiculoselecionado",
            msg =>
            {
                Navigation.PushAsync(new DetalhesView(msg));
            });
            await viewmodel.getveiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "veiculoselecionado");
        }

        void listViewVeiculos_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            //DisplayAlert("Test Drive", string.Format("Você tocou no modelo '{0}', que custa {1}", veiculo.Nome, veiculo.PrecoFormatado), "ok");
            Navigation.PushAsync(new DetalhesView(veiculo));
        }
    }
}
