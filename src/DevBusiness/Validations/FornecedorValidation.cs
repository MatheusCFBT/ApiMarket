using DevBusiness.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBusiness.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor==TipoFornecedor.PessoaFisica,() =>
            {
                RuleFor(f => f.Documento.Length)
            })

             When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
             {
                 RuleFor(f => f.Documento.Length)
            })
        }
    }
}
