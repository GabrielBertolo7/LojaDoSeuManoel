namespace LojaDoSeuManoel.Models
{
    public class Caixa
    {
        public int CaixaId { get; set; }
        public string Nome { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
        public int Volume => Altura * Largura * Comprimento;

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public bool CabeProduto(Produto produto)
        {
            var dproduto = new[] { produto.Altura, produto.Largura, produto.Comprimento };
            var dcaixa = new[] { Altura, Largura, Comprimento };

            Array.Sort(dproduto);
            Array.Sort(dcaixa);

            for (int i = 0; i < 3; i++)
            {
                if (dproduto[i] > dcaixa[i])
                    return false;
            }
            return true;
        }
    }
}
