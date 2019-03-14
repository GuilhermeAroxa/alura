using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using alura.Models;
using Xamarin.Forms;

namespace alura
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                            new KeyValuePair<string, string>("email", login.Email),
                            new KeyValuePair<string, string>("senha", login.Senha)
                        });

                    cliente.BaseAddress = new Uri("http://aluracar.herokuapp.com/");

                    var resultado = await cliente.PostAsync("/login", camposFormulario);
                    var temp = new Usuario();
                    if (resultado.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send<Usuario>(temp, "LoginSucesso");
                    }
                    else
                    {
                        MessagingCenter.Send(new LoginException("Os dados inseridos não correspondem a nenhum login em nossa base de dados"), "LoginFalha");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessagingCenter.Send(new LoginException("Falha na conexào com o servidor, verifique sua conexão com a internet"), "LoginFalha");
            }

        }

    }
    class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
