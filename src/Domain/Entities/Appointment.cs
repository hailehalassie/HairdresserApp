using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; init; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ServiceId { get; set; }
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public Status Status { get; set; } = Status.Pending;

        public Service Service { get; set; } = null!;

    }
}