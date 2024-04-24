using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanHouseMVC.Models
{
    [Table("TB_Aplicativos")]
    public class Aplicativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório, ex: JOGO, APP...")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A nome é obrigatório.")]
        public string Nome { get; set; }

        public int ComputadorId { get; set; }
        public Computador? Computador { get; set; }
    }
}
