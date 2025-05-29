namespace LojaDoSeuManoel.Models
{
    public class CaixaEmpacotada
    {
        public int CaixaId { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }

    public class PedidoEmpacotado
    {
        public int PedidoId { get; set; }
        public List<CaixaEmpacotada> Caixas { get; set; } = new List<CaixaEmpacotada>();
    }
}
