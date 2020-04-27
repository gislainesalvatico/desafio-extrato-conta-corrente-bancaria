using CCB.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCB.Infra.Data.Mapping
{
    public class ExtratoMap : IEntityTypeConfiguration<Extrato>
    {
        public void Configure(EntityTypeBuilder<Extrato> builder)
        {
            builder.ToTable("Extrato");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Data)
                .IsRequired()
                .HasColumnName("Data");

            builder.Property(c => c.Historico)
                .IsRequired()
                .HasColumnName("Historico");

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("Valor");

            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasColumnName("Tipo");
        }
    }
}