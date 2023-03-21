using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.Infra
{
    public class GerenciamentoEstoqueDataContext : DbContext
    {
        public GerenciamentoEstoqueDataContext(DbContextOptions<GerenciamentoEstoqueDataContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
        }
    }
}
