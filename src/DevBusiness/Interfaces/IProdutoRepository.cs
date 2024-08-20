using DevBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBusiness.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid id);

        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        Task<Produto> ObterProdutoFornecedor(Guid fornecedorId);
    }
}
