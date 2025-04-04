using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaContato.Models
{
    public class GRUPOCONTATO
    {
        [Key]
        [Column("GRUPO_ID")]
        public int GRUPO_ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("GRUPO_NOME")]
        public string GRUPO_NOME { get; set; }

        public ICollection<CONTATOGRUPO> CONTATOGRUPOS { get; set; }
    }
}
