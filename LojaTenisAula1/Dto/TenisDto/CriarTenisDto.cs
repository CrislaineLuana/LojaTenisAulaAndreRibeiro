using System.ComponentModel.DataAnnotations;

namespace LojaTenisAula1.Dto.TenisDto
{
    public class CriarTenisDto
    {

        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite a Marca!")]
        public string Marca { get; set; } = string.Empty;


        public string Foto { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite o Valor!")]
        public double Valor { get; set; }
    }
}
