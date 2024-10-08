﻿using Desafio.WebApp.Domain.Pedidos.Entities;
using Desafio.WebApp.Domain.Pedidos.Repositories.Contracts;
using Desafio.WebApp.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.WebApp.Domain.Pedidos.Repositories;

public class PedidoRepository: IPedidoRepository
{
    private readonly DbContextDesafio _context;

    public PedidoRepository(DbContextDesafio context)
    {
        _context = context;
    }

    public async Task<Pedido?> ObterPedido(int pedidoId)
    {
        return await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == pedidoId);
    }

    public Task CancelarPedidoAsync(int pedidoId)
    {
        throw new NotImplementedException();
    }

    public async Task CriarPedidoAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarPedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }
}
