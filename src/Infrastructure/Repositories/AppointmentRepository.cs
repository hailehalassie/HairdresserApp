using Application.Interfaces.Repositories;
using Application.Responses.Appointments;
using Domain.Entities;
using Infrastructure.Data;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AppointmentDetailsResponse?> GetAppointmentById(Guid appointmentId)
        {
            var result = await (
                from a in _context.Appointments
                join barber in _context.Users on a.BarberId equals barber.Id
                join customer in _context.Users on a.CustomerId equals customer.Id
                join service in _context.Services on a.ServiceId equals service.Id
                where a.Id == appointmentId
                select new AppointmentDetailsResponse
                {
                    Id = a.Id,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    ServiceId = a.ServiceId,
                    ServiceName = service.Name,
                    CustomerId = a.CustomerId,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    BarberId = a.BarberId,
                    BarberName = barber.FirstName + " " + barber.LastName,
                    Status = a.Status.ToString() 
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<AppointmentDetailsResponse>> GetAppointmentsByBarberId(Guid barberId)
        {
            var result = await (
                from a in _context.Appointments
                join barber in _context.Users on a.BarberId equals barber.Id
                join customer in _context.Users on a.CustomerId equals customer.Id
                join service in _context.Services on a.ServiceId equals service.Id
                where a.BarberId == barberId && a.Status != Status.Cancelled
                orderby a.StartTime descending
                select new AppointmentDetailsResponse
                {
                    Id = a.Id,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    ServiceId = a.ServiceId,
                    ServiceName = service.Name,
                    CustomerId = a.CustomerId,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    BarberId = a.BarberId,
                    BarberName = barber.FirstName + " " + barber.LastName,
                    Status = a.Status.ToString()
                }).ToListAsync();

            return result;
        }
        
        public async Task<List<AppointmentDetailsResponse>> GetAppointmentsByCustomerId(Guid customerId)
        {
            var result = await (
                from a in _context.Appointments
                join barber in _context.Users on a.BarberId equals barber.Id
                join customer in _context.Users on a.CustomerId equals customer.Id
                join service in _context.Services on a.ServiceId equals service.Id
                where a.CustomerId == customerId && a.Status != Status.Cancelled
                orderby a.StartTime descending
                select new AppointmentDetailsResponse
                {
                    Id = a.Id,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    ServiceId = a.ServiceId,
                    ServiceName = service.Name,
                    CustomerId = a.CustomerId,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    BarberId = a.BarberId,
                    BarberName = barber.FirstName + " " + barber.LastName,
                    Status = a.Status.ToString()
                }).ToListAsync();

            return result;
        }
    }
}