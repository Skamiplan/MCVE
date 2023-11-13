using MCVE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCVE.Infrastructure
{
    internal class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> entity)
        {
            entity.HasOne(o => o.Ticket).WithMany(organizationGroup => organizationGroup.Options).HasForeignKey(c => c.TicketId);

            entity.HasIndex(p => new { p.TicketId, }).IncludeProperties(p => new { p.OptionId });
        }
    }
}