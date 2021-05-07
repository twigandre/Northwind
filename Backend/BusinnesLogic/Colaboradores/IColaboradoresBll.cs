using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using System.Threading.Tasks;
using Northwind.Database.Dto;

namespace Northwind.BusinnesLogic.Colaboradores
{
    public interface IColaboradoresBll
    {
        List<FuncionariosDto> Listar(Order pagedFilter);
    }
}
