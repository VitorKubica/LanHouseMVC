using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanHouseMVC.Models
{
    [Table("TB_Perifericos")]
    public class Periferico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatório.")]
        public string Marca { get; set; }

        public int ComputadorId { get; set; }
        public Computador? Computador { get; set; }
    }
}
