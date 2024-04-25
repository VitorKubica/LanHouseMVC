using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanHouseMVC.Models
{
    [Table("TB_InfoContato")]
    public class InfoContato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Phone(ErrorMessage = "Esse número de telefone é inválido")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Esse email é inválido.")]
        public string Email { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
