using Application.Features.Appointments.Create;
using Application.Features.Appointments.Get;
using Application.Features.Appointments.GetByBarber;
using Application.Features.Appointments.GetByCustomer;
using Application.Requests.Appointments;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            var result = await _mediator.Send(new CreateAppointmentCmd(request));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            var result = await _mediator.Send(new GetAppointmentQry(id));
            return result != null ? Ok(result) : NotFound("Appointment not found");
        }

        [HttpGet("barber/{barberId}")]
        public async Task<IActionResult> GetAppointmentsByBarber(Guid barberId)
        {
            var result = await _mediator.Send(new GetByBarberQry(barberId));
            return result != null && result.Count > 0 ? Ok(result) : NotFound("No appointments found for this barber");
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAppointmentsByCustomer(Guid customerId)
        { 
            var result = await _mediator.Send(new GetByCustomerQry(customerId));
            return result != null && result.Count > 0 ? Ok(result) : NotFound("No appointments found for this customer");
        }
    }
}