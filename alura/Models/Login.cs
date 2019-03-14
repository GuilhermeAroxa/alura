using System;
namespace alura.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Login(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;
        }
    }
}
