using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaContato.Models
{
    public class CONTATOGRUPO
    {
        [Key]
        [Column("CONT_GRUP_ID")]
        public int CONT_GRUP_ID { get; set; }

        [Column("CONTATO_ID")]
        public int CONTATO_ID { get; set; }

        [Column("GRUPO_ID")]
        public int GRUPO_ID { get; set; }

        [ForeignKey("CONTATO_ID")]
        public CONTATO CONTATO { get; set; }

        [ForeignKey("GRUPO_ID")]
        public GRUPOCONTATO GRUPOCONTATO { get; set; }
    }

}
