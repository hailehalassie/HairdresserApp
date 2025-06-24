using Application.Features.Appointments.Create;
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

        // [HttpGet]
        // public async Task<ActionResult<List<Appointment>>> GetAppointments()
        // {
        //     var appointments = await _context.Appointments.ToListAsync();
        //     return Ok(appointments);
        // }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            var result = await _mediator.Send(new CreateAppointmentCmd(request));
            return Ok(result);
        }
    }
}