using DevBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBusiness.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Remover(Produto produto);
    }
}
