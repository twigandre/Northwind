using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using Northwind.Database.Dto;
using Northwind.Database.Repository;
using System;

namespace Northwind.BusinnesLogic.Produto
{
    public class ProdutoBll : IProdutoBll
    {
        IRepository<Supplier> _repositoryFornecedor;
        IRepository<Product> _repositoryProdutos;
        IRepository<Category> _repositoryCategorias;

        public ProdutoBll(IRepository<Supplier> repositoryFornecedor,
                          IRepository<Product> repositoryProdutos,
                          IRepository<Category> repositoryCategorias)
        {
            _repositoryFornecedor = repositoryFornecedor;
            _repositoryProdutos = repositoryProdutos;
            _repositoryCategorias = repositoryCategorias;
        }

        public ProdutosDto ListarCombobox()
        {
            return new ProdutosDto {
                ListCategorias = _repositoryCategorias.Listar(),
                ListFornecedor = _repositoryFornecedor.Listar()
            };
        }

        public List<Product> ListarProdutos(Product pagedFilter)
        {
            try
            {
                var ListaPedidos = _repositoryProdutos.Listar(o =>
                               (
                                   pagedFilter.CategoryId == -1 || o.CategoryId == pagedFilter.CategoryId
                               ) 
                               &&
                               (
                                   pagedFilter.SupplierId == -1 || o.SupplierId == pagedFilter.SupplierId
                               )
                           );

                if (ListaPedidos.Count == 0)
                    return null;

                return ListaPedidos;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }


    }
}
