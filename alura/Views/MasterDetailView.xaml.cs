using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alura.Models;
using Xamarin.Forms;

namespace alura.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMetodos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DesinscreverMetodos();
        }

        private void AssinarMetodos()
        {
            MessagingCenter.Subscribe<Usuario>(this, "MostrarMeusAgendamentos", (usuario) =>
            {
                this.Detail = new NavigationPage(new AgendamentosUsuarioView());
                this.IsPresented = false;
            });
            MessagingCenter.Subscribe<Usuario>(this, "NovoAgendamento", (usuario) =>
            {
                this.Detail = new NavigationPage(new ListagemView(usuario));
                this.IsPresented = false;
            });
        }

        private void DesinscreverMetodos()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "MostrarMeusAgendamentos");
            MessagingCenter.Unsubscribe<Usuario>(this, "NovoAgendamento");
        }
    }
}
