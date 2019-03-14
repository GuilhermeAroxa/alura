using System;
using System.Collections.Generic;
using alura.Models;
using alura.ViewModels;
using Xamarin.Forms;

namespace alura.Views
{
    public partial class MasterView : ContentPage
    {
        public MasterViewModel ViewModel { get; private set; }

        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = this.ViewModel;
        }

        public MasterView()
        {

        }
    }
}