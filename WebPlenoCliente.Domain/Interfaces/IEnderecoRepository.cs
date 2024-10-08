﻿using WebPlenoCliente.Domain.Entidades;

namespace WebPlenoCliente.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> BuscarEnderecosPorClienteAsync(int clienteId);
        Task<IEnumerable<Endereco>> BuscarEnderecosAsync();
        Task<Endereco> BuscarEnderecoPorIdAsync(int id);
        Task<Endereco> AdicionarEnderecoAsync(Endereco endereco);
        Task AlterarEnderecoAsync(Endereco endereco);
        Task DeletarEnderecoAsync(int id);
        Task<bool> EnderecoExisteAsync(Endereco endereco);
    }
}
