using Dapper;
using System.Data;
using WebPlenoCliente.Domain.Entidades;
using WebPlenoCliente.Domain.Interfaces;

namespace WebPlenoCliente.Infra.Repositories
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Cliente> BuscarClientePorIdAsync(int id)
        {
            var sql = "SELECT * FROM Clientes WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Cliente>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Cliente>> BuscarClientesAsync()
        {
            var sql = "SELECT * FROM Clientes";
            return await _dbConnection.QueryAsync<Cliente>(sql);
        }

        public async Task<Cliente> AdicionarClienteAsync(Cliente cliente)
        {
            var sql = "INSERT INTO Clientes (Nome, Email, Telefone, DataNascimento) VALUES (@Nome, @Email, @Telefone, @DataNascimento); SELECT LAST_INSERT_ID();";
            var clienteId = await _dbConnection.QuerySingleAsync<int>(sql, cliente);

            return await BuscarClientePorIdAsync(clienteId);
        }

        public async Task AlterarClienteAsync(Cliente cliente)
        {
            var sql = "UPDATE Clientes SET Nome = @Nome, Email = @Email, Telefone = @Telefone, DataNascimento = @DataNascimento WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, cliente);
        }

        public async Task DeletarClienteAsync(int id)
        {
            var sql = "DELETE FROM Clientes WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
