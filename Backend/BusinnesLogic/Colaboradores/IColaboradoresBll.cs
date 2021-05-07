using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using System.Threading.Tasks;

namespace Northwind.BusinnesLogic.Colaboradores
{
    public interface IColaboradoresBll
    {
        List<string> Listar(Order pagedFilter);
    }
}
