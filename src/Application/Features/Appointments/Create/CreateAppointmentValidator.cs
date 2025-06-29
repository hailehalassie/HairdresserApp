using FluentValidation;

namespace Application.Features.Appointments.Create
{ 
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCmd>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Start time must be in the future.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime).WithMessage("End time must be after start time.");

            RuleFor(x => x.ServiceId)
                .NotEmpty().WithMessage("Service ID is required.");

            RuleFor(x => x.BarberId)
                .NotEmpty().WithMessage("Barber ID is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");
        }
    }
}