using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services.Interfaces;

namespace LojaDoSeuManoel.Services
{
    public class EmpacotadorService : IEmpacotadorService
    {
        private readonly List<Caixa> caixasDisponiveis = new List<Caixa>
        {
            new Caixa { Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };

        public List<RespostaEmpacotamento> EmpacotarPedidos(List<Pedido> pedidos)
        {
            var respostas = new List<RespostaEmpacotamento>();

            foreach (var pedido in pedidos)
            {
                var caixasUsadas = EmpacotarPedido(pedido);
                respostas.Add(new RespostaEmpacotamento
                {
                    PedidoId = pedido.PedidoId,
                    CaixasUsadas = caixasUsadas
                });
            }

            return respostas;
        }

        private List<CaixaComProdutos> EmpacotarPedido(Pedido pedido)
        {
            var caixasUsadas = new List<CaixaComProdutos>();

            var produtosParaEmpacotar = OrdenarProdutosPorVolume(pedido.Produtos);

            while (produtosParaEmpacotar.Any())
            {
                var caixaAtual = TentarEmpacotarEmCaixa(produtosParaEmpacotar);

                if (caixaAtual == null)
                    throw new Exception("Não foi possível empacotar todos os produtos com as caixas disponíveis.");

                RemoverProdutosEmpacotados(produtosParaEmpacotar, caixaAtual.Produtos);
                caixasUsadas.Add(caixaAtual);
            }

            return caixasUsadas;
        }

        private List<Produto> OrdenarProdutosPorVolume(List<Produto> produtos)
        {
            return produtos.OrderByDescending(p => p.Altura * p.Largura * p.Comprimento).ToList();
        }

        private CaixaComProdutos TentarEmpacotarEmCaixa(List<Produto> produtosParaEmpacotar)
        {
            foreach (var caixa in caixasDisponiveis.OrderBy(c => c.Volume))
            {
                var produtosNaCaixa = new List<Produto>();
                int volumeCaixa = caixa.Volume;
                int volumeProdutos = 0;

                foreach (var produto in produtosParaEmpacotar.ToList())
                {
                    int volumeProduto = produto.Altura * produto.Largura * produto.Comprimento;

                    if (caixa.CabeProduto(produto) && (volumeProdutos + volumeProduto <= volumeCaixa))
                    {
                        produtosNaCaixa.Add(produto);
                        volumeProdutos += volumeProduto;
                    }
                }

                if (produtosNaCaixa.Any())
                {
                    return new CaixaComProdutos
                    {
                        NomeCaixa = caixa.Nome,
                        Produtos = produtosNaCaixa
                    };
                }
            }

            return null;
        }

        private void RemoverProdutosEmpacotados(List<Produto> produtosParaEmpacotar, List<Produto> produtosEmpacotados)
        {
            foreach (var produto in produtosEmpacotados)
                produtosParaEmpacotar.Remove(produto);
        }
    }
}
