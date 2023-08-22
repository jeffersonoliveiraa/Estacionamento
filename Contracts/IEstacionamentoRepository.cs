using Estacionamento.Data;

namespace Estacionamento.Contracts
{
    public interface IEstacionamentoRepository
    {
        Task<IEnumerable<EstacionamentoDto>> GetEstacionamento();
        Task<bool> IsertEstacionamento(EstacionamentoDto estacionamentoDto);
        Task<bool> UpadateEstacionamento(EstacionamentoDto estacionamentoDto);
        Task<bool> DeleteEstacionamento(int id);
        Task<EstacionamentoDto> GetEstacionamentoById(int id);
    }
}