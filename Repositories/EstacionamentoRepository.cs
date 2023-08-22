using Dapper;
using Estacionamento.Contracts;
using Estacionamento.Data;
using System.Data;

namespace Estacionamento.Repositories
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly IDbConnection _dbConnection;

        public EstacionamentoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteEstacionamento(int id)
        {
            string query = $"delete Vaga where id = {id}";

            var delete = await _dbConnection.ExecuteAsync(query);

            return delete > 0;
        }

        public async Task<IEnumerable<EstacionamentoDto>> GetEstacionamento()
        {
            string query = "Select * from Vaga";

            return await _dbConnection.QueryAsync<EstacionamentoDto>(query);
        }

        public async Task<EstacionamentoDto> GetEstacionamentoById(int id)
        {
            string query = $"select * from Vaga where id = {id}";

            return await _dbConnection.QueryFirstOrDefaultAsync<EstacionamentoDto>(query);
        }

        public async Task<bool> IsertEstacionamento(EstacionamentoDto estacionamentoDto)
        {
            string query = $"insert into Vaga (nome, cpf, placa, modelo) values (@Nome, @Cpf, @Placa, @Modelo)";

            var saved = await _dbConnection.ExecuteAsync(query, estacionamentoDto);

            return saved > 0;
        }

        public async Task<bool> UpadateEstacionamento(EstacionamentoDto estacionamentoDto)
        {
            string query = $"update Vaga set nome = @Nome, cpf = @Cpf, placa = @Placa, modelo = @Modelo where id = @Id";

            var update = await _dbConnection.ExecuteAsync(query, estacionamentoDto);
            
            return update > 0;
        }
    }
}
