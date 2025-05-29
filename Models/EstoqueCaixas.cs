namespace LojaDoSeuManoel.Models
{
    public static class EstoqueCaixas
    {
        public static List<Caixa> CaixasDisponiveis = new List<Caixa>
        {
            new Caixa { CaixaId = 1, Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { CaixaId = 2, Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { CaixaId = 3, Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };
    }
}
