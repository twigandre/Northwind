using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using Northwind.Database.Repository;
using Northwind.Database.Dto;
using System.Threading.Tasks;

namespace Northwind.BusinnesLogic.Colaboradores
{    
    public class Colaboradores : IColaboradores
    {
        IRepository<Order> _repositoryPedidos;
        IRepository<Employee> _repositoryFuncionario;
        public Colaboradores(IRepository<Order> repositoryPedidos,
                                IRepository<Employee> repositoryFuncionario)
        {
            _repositoryPedidos = repositoryPedidos;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public List<Funcionarios> Listar(Order pagedFilter)
        {
            var retornoMetodo = new List<Funcionarios>();
            try
            {
				var dataPedido = pagedFilter.OrderDate == null ? new DateTime(1, 1, 1) : new DateTime(pagedFilter.OrderDate.Value.Year, pagedFilter.OrderDate.Value.Month, pagedFilter.OrderDate.Value.Day);
				var dataExpedicao = pagedFilter.ShippedDate == null ? new DateTime(1, 1, 1) : new DateTime(pagedFilter.ShippedDate.Value.Year, pagedFilter.ShippedDate.Value.Month, pagedFilter.ShippedDate.Value.Day, 23, 59, 59);

                var FuncionariosDto = _repositoryFuncionario.Listar().Select(x => new Funcionarios() { 
                        EmployerId = (int)x.EmployeeId,
                        Nome = x.FirstName + " " + x.LastName,
                        QtdPedidosAtendidos = _repositoryPedidos.Listar(o => (o.EmployeeId == x.EmployeeId) &&
                                                                             (pagedFilter.OrderDate == null || (o.OrderDate >= dataPedido && o.ShippedDate <= dataExpedicao) )
                                                                       ).Count()
                }).ToList();

                return FuncionariosDto;
            }
			catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
