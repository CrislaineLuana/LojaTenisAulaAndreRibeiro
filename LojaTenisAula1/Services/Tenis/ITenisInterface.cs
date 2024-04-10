using LojaTenisAula1.Dto.TenisDto;
using LojaTenisAula1.Models;

namespace LojaTenisAula1.Services.Tenis
{
    public interface ITenisInterface
    {
        Task<List<TenisModel>> BuscarTenis();
        Task<TenisModel> BuscarTenisPorId(int? id);
        Task<List<TenisModel>> BuscarTenisFiltro(string? pesquisar);
        Task<TenisModel> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto);
        Task<TenisModel> Editar(TenisModel tenisModel, IFormFile? foto);
    }
}
