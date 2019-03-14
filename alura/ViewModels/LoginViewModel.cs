using System;
using System.Windows.Input;
using alura.Models;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(Usuario, Senha));
            }, () =>
             {
                 return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Senha);
             }
            );
        }
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                this.usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                this.senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public ICommand EntrarCommand { get; private set; }
    }
}