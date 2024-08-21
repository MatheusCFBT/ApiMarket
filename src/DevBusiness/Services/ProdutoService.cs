using DevBusiness.Interfaces;
using DevBusiness.Models;
using DevBusiness.Validations;

namespace DevBusiness.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Remover(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
