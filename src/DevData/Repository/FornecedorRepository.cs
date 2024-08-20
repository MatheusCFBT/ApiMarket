using DevBusiness.Interfaces;
using DevBusiness.Models;
using DevData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevData.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await meuDb.Fornecedores.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await meuDb.Fornecedores.AsNoTracking().Include(p => p.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
