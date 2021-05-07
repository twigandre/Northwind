﻿using Microsoft.AspNetCore.Mvc;
using Northwind.BusinnesLogic.Produto;
using Northwind.Database.Dto;
using Northwind.Database.Models;
using System.Collections.Generic;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        IProdutoBll _produtoBll;
        public ProdutosController(IProdutoBll produtoBll)
        {
            _produtoBll = produtoBll;
        }

        /// <summary>
        /// Listar combobox dos dos Clientes
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public ProdutosDto ListarCombobox() => _produtoBll.ListarCombobox();

        /// <summary>
        /// Disponibilizar uma API para listagem de produtos por fornecedor ou categorias.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public List<Product> ListarProdutos([FromQuery] Product pagedFilter) => _produtoBll.ListarProdutos(pagedFilter);

    }
}
