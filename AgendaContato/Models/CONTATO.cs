using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaContato.Models
{
    public class CONTATO
    {
        [Key]
        [Column("CONTATO_COD")]
        public int CONTATO_COD { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100)]
        [Column("CONTATO_NOME")]
        public string CONTATO_NOME { get; set; }

        [Required(ErrorMessage = "O campo Numero do Telefone é obrigatório")]
        [MaxLength(30)]
        [Column("CONTATO_NUMERO")]
        public string CONTATO_NUMERO { get; set; }

        [Column("TIPO_COD")]
        public int TIPO_COD { get; set; }

        [Column("CONTATO_FAVORITO")]
        public bool CONTATO_FAVORITO { get; set; } = false;

        [ForeignKey("TIPO_COD")]
        public TIPOCONTATO TIPOCONTATO { get; set; }

        public ICollection<CONTATOGRUPO> CONTATOGRUPOS { get; set; }
    }
}
