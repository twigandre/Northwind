using System.Collections.Generic;
using Northwind.Database.Models;
using Northwind.Database.Dto;

namespace Northwind.BusinnesLogic.Pedido
{
    public interface IPedidoBll
    {
        PedidosDto ListaComboBox();
        List<Order> ListaPedidos(Order pagedFilter);
    }
}
