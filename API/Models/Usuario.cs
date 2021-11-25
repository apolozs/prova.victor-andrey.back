using System;

namespace API.Models
{
    public class Usuario
    {
        public Usuario() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
        public string Token { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}