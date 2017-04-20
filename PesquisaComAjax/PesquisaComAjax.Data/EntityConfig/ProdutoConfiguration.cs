using PesquisaComAjax.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PesquisaComAjax.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {

            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Valor)
                .IsRequired();

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsRequired();


            Property(p => p.Imagem)
                .IsRequired();

        }
    }
}
