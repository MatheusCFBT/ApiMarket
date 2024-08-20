using System.ComponentModel.DataAnnotations;

namespace DevApi.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracteres")]
        public string? Descricao { get; set; }

        public string? ImagemUpload { get; set; }

        public string? Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public string? NomeFornecedor { get; set; }
    }
}
