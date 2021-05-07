using System.Collections.Generic;
using Northwind.Database.Models;

namespace Northwind.Database.Dto
{
    public class Produtos
    {
        public List<Supplier> ListFornecedor { get; set; }
        public List<Category> ListCategorias { get; set; }
    }
}
