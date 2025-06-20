using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        
        [ValidateNever]
        public ICollection<CONTATO> CONTATOS { get; set; }
    }
}
