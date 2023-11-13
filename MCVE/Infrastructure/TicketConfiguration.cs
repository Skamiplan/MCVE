using MCVE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCVE.Infrastructure
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasMany(o => o.Options).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}