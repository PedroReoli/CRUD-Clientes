namespace SeuProjeto.Models
{
    public class Cliente
    {
        public int Id { get; set; }  // ID será utilizado internamente, mas não será exibido nos detalhes
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
