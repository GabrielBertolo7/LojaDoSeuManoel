using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Services.Interfaces
{
    public interface IEmpacotadorService
    {
        List<RespostaEmpacotamento> EmpacotarPedidos(List<Pedido> pedidos);
    }
}
