using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Models
{
    public class Contato
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Numero do Telefone é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria")]
        public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
