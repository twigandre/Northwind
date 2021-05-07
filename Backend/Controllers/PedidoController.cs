using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Northwind.Database.Models;
using Northwind.BusinnesLogic.Pedido;
using Northwind.Database.Dto;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        IPedido _pedidoBll;
        public PedidoController(IPedido pedidoBll)
        {
            _pedidoBll = pedidoBll;
        }

        /// <summary>
        /// Disponibilizar uma API para listagem de pedidos por Clientes ou expedidores.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public List<Order> ListarPedidos([FromQuery] Order pagedFilter) => _pedidoBll.ListaPedidos(pagedFilter);


        /// <summary>
        /// Listar combobox dos dos Clientes
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public Pedidos ListarCombobox() => _pedidoBll.ListaComboBox();
    }
}

