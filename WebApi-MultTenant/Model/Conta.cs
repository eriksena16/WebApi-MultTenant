namespace WebApi_MultTenant.Model
{
    public class Conta : Entidade
    {
        public string Nome { get; set; }
        public long ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
