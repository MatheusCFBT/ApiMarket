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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await meuDb.Enderecos.AsNoTracking().FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
