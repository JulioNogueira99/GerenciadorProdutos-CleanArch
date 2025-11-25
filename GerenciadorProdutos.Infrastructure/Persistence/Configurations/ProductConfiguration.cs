using GerenciadorProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorProdutos.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Definindo a Tabela
            builder.ToTable("Products");

            // Chave Primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100); // Importante limitar strings no banco

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Sempre defina precisão para dinheiro

            // Dica de Ouro: Como a classe Product tem "private set", 
            // o EF consegue setar via reflection, então não precisa fazer nada especial aqui
            // a menos que use Backing Fields.
        }
    }
}