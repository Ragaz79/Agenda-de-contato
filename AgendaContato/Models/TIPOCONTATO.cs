using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AgendaContato.Models
{
    public class TIPOCONTATO
    {
        [Key]
        [Column("TIPO_COD")]
        public int TIPO_COD { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("TIPO_NOME")]
        public string TIPO_NOME { get; set; }

        public ICollection<CONTATO> CONTATOS { get; set; }
    }
}
