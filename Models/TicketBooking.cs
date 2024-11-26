using System;
using System.Collections.Generic;
using website2.Models;

namespace website2.Models;

public partial class Ticketbooking
{
    public int TicketbookingId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DateBooked { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}