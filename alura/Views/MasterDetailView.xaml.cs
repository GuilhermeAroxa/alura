using System;
using System.Collections.Generic;
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
        }
    }
}
