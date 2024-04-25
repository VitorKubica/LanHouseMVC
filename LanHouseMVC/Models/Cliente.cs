using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanHouseMVC.Models
{
    [Table("TB_Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string CPF { get; set; }

    }
}