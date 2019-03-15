using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alura.Models;
using alura.ViewModels;
using Xamarin.Forms;
using alura.Views;

namespace alura.Views
{
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ReceberMensagens();
        }

        private void ReceberMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                (usuario) =>
                {
                    this.CurrentPage = this.Children[1];
                }
            );
            MessagingCenter.Subscribe<Usuario>(this, "SalvarPerfil",
                (usuario) =>
                {
                    this.CurrentPage = this.Children[0];
                }
            );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            DesinscreverMensagens();
        }

        private void DesinscreverMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SalvarPerfil");
        }
    }
}
