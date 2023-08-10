namespace WebApi_MultTenant.Model
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Slug { get; set; }

        public Conta Conta { get; set; }
    }
}
