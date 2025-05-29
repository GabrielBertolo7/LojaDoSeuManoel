namespace LojaDoSeuManoel.Models
{
    public class RespostaEmpacotamento
    {
        public int PedidoId { get; set; }
        public List<CaixaComProdutos> CaixasUsadas { get; set; }
    }

    public class CaixaComProdutos
    {
        public string NomeCaixa { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
