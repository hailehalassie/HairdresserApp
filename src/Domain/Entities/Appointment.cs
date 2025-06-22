using System;

namespace Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ServiceId { get; set; }
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public int UserId { get; set; }

        //TODO: Add navigation properties for User, Barber, Customer, and Service
    }
}