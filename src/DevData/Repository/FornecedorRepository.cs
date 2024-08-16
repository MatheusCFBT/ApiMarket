using DevBusiness.Models;
using DevBusiness.Interfaces
using DevData.Context
using Microsoft.EntityFrameworkCore
using System;

namespace DevData.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Fornecedor> GetFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> GetFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
