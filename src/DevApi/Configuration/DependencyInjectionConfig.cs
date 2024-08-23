using DevBusiness.Interfaces;
using DevBusiness.Notificacoes;
using DevBusiness.Services;
using DevData.Context;
using DevData.Repository;

namespace DevApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<MeuDbContext>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<INotificador, Notificador>();
            builder.Services.AddScoped<IFornecedorService, FornecedorService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();

            return builder;
        }
    }
}
