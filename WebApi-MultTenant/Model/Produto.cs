namespace WebApi_MultTenant.Model
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
