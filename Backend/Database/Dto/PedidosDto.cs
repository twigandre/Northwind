using System.Collections.Generic;
using Northwind.Database.Models;

namespace Northwind.Database.Dto
{
    public class PedidosDto
    {
        public List<Shipper> ListExpedidores { get; set; }
        public List<Customer> ListClientes { get; set; }
    }
}
