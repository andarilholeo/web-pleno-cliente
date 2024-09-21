using Dapper;
using System.Data;
using WebPlenoCliente.Domain.Entidades;
using WebPlenoCliente.Domain.Interfaces;

namespace WebPlenoCliente.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection _dbConnection;

        public EnderecoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Endereco>> BuscarEnderecosPorClienteAsync(int clienteId)
        {
            var sql = "SELECT id, cliente_id AS ClienteID, cep, rua, numero, complemento, bairro, cidade, estado FROM Enderecos WHERE cliente_id = @ClienteID";
            return await _dbConnection.QueryAsync<Endereco>(sql, new { ClienteID = clienteId });
        }

        public async Task<Endereco> BuscarEnderecoPorIdAsync(int id)
        {
            var sql = "SELECT id, cliente_id AS ClienteID, cep, rua, numero, complemento, bairro, cidade, estado FROM Enderecos WHERE id = @Id";

            var teste = await _dbConnection.QuerySingleOrDefaultAsync<Endereco>(sql, new { Id = id });
            return await _dbConnection.QuerySingleOrDefaultAsync<Endereco>(sql, new { Id = id });
        }

        public async Task<Endereco> AdicionarEnderecoAsync(Endereco endereco)
        {
            var sql = "INSERT INTO Enderecos (cliente_id, cep, rua, numero, complemento, bairro, cidade, estado) VALUES (@ClienteID, @CEP, @Rua, @Numero, @Complemento, @Bairro, @Cidade, @Estado); SELECT LAST_INSERT_ID();";
            var enderecoId = await _dbConnection.QuerySingleAsync<int>(sql, endereco);

            return await BuscarEnderecoPorIdAsync(enderecoId);
        }

        public async Task AlterarEnderecoAsync(Endereco endereco)
        {
            var sql = "UPDATE Enderecos SET cep = @CEP, rua = @Rua, numero = @Numero, complemento = @Complemento, bairro = @Bairro, cidade = @Cidade, estado = @Estado WHERE id = @Id";
            await _dbConnection.ExecuteAsync(sql, endereco);
        }

        public async Task DeletarEnderecoAsync(int id)
        {
            var sql = "DELETE FROM Enderecos WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
