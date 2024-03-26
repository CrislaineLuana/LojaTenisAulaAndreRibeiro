using System.ComponentModel.DataAnnotations;

namespace LojaTenisAula1.Models
{
    public class TenisModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite a Marca!")]
        public string Marca { get; set; } = string.Empty;


        [Required(ErrorMessage = "Insira a Foto!")]
        public string Foto { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite o Valor!")]
        public double Valor { get; set; }
    }
}
