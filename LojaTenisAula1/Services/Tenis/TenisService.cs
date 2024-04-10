using LojaTenisAula1.Data;
using LojaTenisAula1.Dto.TenisDto;
using LojaTenisAula1.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAula1.Services.Tenis
{
    public class TenisService : ITenisInterface
    {
        private readonly AppDbContext _context;
        private readonly string _sistema;
        public TenisService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }
        public async Task<List<TenisModel>> BuscarTenis()
        {
            try
            {

                return await _context.Tenis.ToListAsync();

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TenisModel>> BuscarTenisFiltro(string? pesquisar)
        {
            try
            {

                var tenis = await _context.Tenis
                    .Where(tenisBanco => tenisBanco.Nome.Contains(pesquisar) 
                                        || tenisBanco.Marca.Contains(pesquisar)).ToListAsync();

                return tenis;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TenisModel> BuscarTenisPorId(int? id)
        {
            try
            {
                return await _context.Tenis.FirstOrDefaultAsync(tenis => tenis.Id == id);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TenisModel> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto)
        {
            try
            {
                var nomeCaminhoImagem = GeraCaminhoArquivo(foto);

                var tenis = new TenisModel()
                {
                    Nome = criarTenisDto.Nome,
                    Marca = criarTenisDto.Marca,
                    Valor = criarTenisDto.Valor,
                    Foto = nomeCaminhoImagem
                };

                _context.Add(tenis);
                await _context.SaveChangesAsync();

                return tenis;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TenisModel> Editar(TenisModel tenisModel, IFormFile? foto)
        {
            try
            {
                var tenis = await _context.Tenis.FirstOrDefaultAsync(tenisBanco => tenisBanco.Id == tenisModel.Id);

                var nomeCaminhoImagem = "";
                if(foto != null)
                {
                    string caminhoFotoExistente = _sistema + "\\imagem\\" + tenis.Foto;

                    if (File.Exists(caminhoFotoExistente))
                    {
                        File.Delete(caminhoFotoExistente);
                    }

                    nomeCaminhoImagem = GeraCaminhoArquivo(foto);
                }

                tenis.Nome = tenisModel.Nome;
                tenis.Marca = tenisModel.Marca;
                tenis.Valor = tenisModel.Valor;

                if(nomeCaminhoImagem != "")
                {
                    tenis.Foto = nomeCaminhoImagem;
                }

                _context.Update(tenis);
                await _context.SaveChangesAsync();

                return tenis;



            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GeraCaminhoArquivo(IFormFile foto)
        {

            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";

            string caminhoParaSalvarImagens = _sistema + "\\imagem\\";

            if (!Directory.Exists(caminhoParaSalvarImagens))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }

            using (var stream = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
            {
                foto.CopyToAsync(stream).Wait();
            }

            return nomeCaminhoImagem;

        }



    }
}
