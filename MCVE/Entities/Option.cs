using System.ComponentModel.DataAnnotations;

using MCVE.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace MCVE.Entities
{
    [EntityTypeConfiguration(typeof(OptionConfiguration))]

    public class Option
    {
        public Guid Id { get; set; }

        public Guid TicketId { get; set; }

        public virtual Ticket? Ticket { get; set; }
    }
}
