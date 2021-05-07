﻿using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Database.Models;
using Northwind.Database.Dto;
using Northwind.Database.Repository;

namespace Northwind.BusinnesLogic.Pedido
{
    public class PedidoBll : IPedidoBll
    {
        IRepository<Order> _repositoryPedidos;
        IRepository<Customer> _repositoryClientes;
        IRepository<Shipper> _repositoryExpedidores;

        public PedidoBll(IRepository<Order> repositoryPedidos,
                         IRepository<Customer> repositoryClientes,
                         IRepository<Shipper> repositoryExpedidores)
        {
            _repositoryPedidos = repositoryPedidos;
            _repositoryClientes = repositoryClientes;
            _repositoryExpedidores = repositoryExpedidores;
        }

        public PedidosDto ListaComboBox()
        {
            var Cliente = _repositoryClientes.Listar();
            //var Expedidores = _repositoryExpedidores.Listar();

            return new PedidosDto {
                ListClientes = Cliente//,
                //ListExpedidores = Expedidores
            };
        }

        public List<Order> ListaPedidos(Order pagedFilter)
        {
            try
            {
                var ListaPedidos = _repositoryPedidos.Listar(o =>
                                (
                                    string.IsNullOrEmpty(pagedFilter.CustomerId) || o.CustomerId.Equals(pagedFilter.CustomerId)
                                )
                            );

                if (ListaPedidos.Count == 0)
                    return null;

                return ListaPedidos;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }         
        }


    }
}
