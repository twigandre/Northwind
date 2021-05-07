using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using Northwind.Database.Repository;
using Northwind.Database.Dto;
using System.Threading.Tasks;

namespace Northwind.BusinnesLogic.Colaboradores
{    
    public class ColaboradoresBll : IColaboradoresBll
    {
        IRepository<Order> _repositoryPedidos;
        IRepository<Employee> _repositoryFuncionario;
        public ColaboradoresBll(IRepository<Order> repositoryPedidos,
                                IRepository<Employee> repositoryFuncionario)
        {
            _repositoryPedidos = repositoryPedidos;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public List<string> Listar(Order pagedFilter)
        {
            try
            {
                var retornoMetodo = new List<string>();
				var dataPedido = pagedFilter.OrderDate == null ? new DateTime(1, 1, 1) : new DateTime(pagedFilter.OrderDate.Value.Year, pagedFilter.OrderDate.Value.Month, pagedFilter.OrderDate.Value.Day);
				var dataExpedicao = pagedFilter.ShippedDate == null ? new DateTime(1, 1, 1) : new DateTime(pagedFilter.ShippedDate.Value.Year, pagedFilter.ShippedDate.Value.Month, pagedFilter.ShippedDate.Value.Day, 23, 59, 59);

				var EmployeList = _repositoryPedidos.Listar(o =>				
					(
						pagedFilter.OrderDate == null || (o.OrderDate >= dataPedido && o.ShippedDate <= dataExpedicao)
					)					
			    );

                if (EmployeList.Count == 0)
                    return null;

                foreach(var item in EmployeList)
                {
                    var Funcionario = _repositoryFuncionario.Selecionar(o => o.EmployeeId == item.EmployeeId);
                    var NomeConcatenado = Funcionario.FirstName + " " + Funcionario.LastName;
                    retornoMetodo.Add(NomeConcatenado);
                }

                return retornoMetodo;
            }
			catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
