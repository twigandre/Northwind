using System.Collections.Generic;
using Northwind.Database.Models;
using Northwind.Database.Dto;

namespace Northwind.BusinnesLogic.Produto
{
    public interface IProdutoBll
    {
        ProdutosDto ListarCombobox();
        List<Product> ListarProdutos(Product pagedFilter);
    }
}
