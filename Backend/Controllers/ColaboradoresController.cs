using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Northwind.Database.Models;
using Northwind.BusinnesLogic.Colaboradores;
using Northwind.Database.Dto;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : Controller
    {
        IColaboradores _colaboradoresBll;
        public ColaboradoresController(IColaboradores colaboradoresBll)
        {
            _colaboradoresBll = colaboradoresBll;
        }

        /// <summary>
        /// Disponibilizar uma API para listagem de colaboradores com visão do quantitativo de pedidos atendidos por período.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public List<Funcionarios> ListaColaboradoresPorDataPedidos([FromQuery] Order pagedFilter) => _colaboradoresBll.Listar(pagedFilter);

      
    }
}
