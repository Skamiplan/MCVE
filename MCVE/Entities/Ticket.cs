using MCVE.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace MCVE.Entities
{
    [EntityTypeConfiguration(typeof(TicketConfiguration))]
    public class Ticket
    {
        public Guid Id { get; set; }

        public virtual ICollection<Option> Options { get; set; } = new HashSet<Option>();
    }
}
