using LojaTenisAula1.Models;

namespace LojaTenisAula1.Services.Tenis
{
    public interface ITenisInterface
    {
        Task<List<TenisModel>> BuscarTenis();
        Task<TenisModel> BuscarTenisPorId(int? id);
    }
}
