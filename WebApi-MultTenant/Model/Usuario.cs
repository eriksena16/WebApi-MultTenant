namespace WebApi_MultTenant.Model
{
    public class Usuario : Entidade
    {
        public long ContaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        


        public Conta Conta { get; set; }
    }
}
