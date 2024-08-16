using System.ComponentModel.DataAnnotations;

namespace DevApi.ViewModels
{
    public class FornecedorViewModel
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "O campo {0} precisa conter entre {2} a {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisa conter entre {2} a {1} caracteres")]
        public string? Documento { get; set; }

        public int TipoFornecedor { get; set; }

        public EnderecoViewModel? Endereco { get; set; }

        public bool Ativo { get; set; }

        public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
    }
}
