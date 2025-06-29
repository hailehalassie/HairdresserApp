using FluentValidation;

namespace Application.Features.Appointments.Cancel
{ 
    public class CancelAppointmentValidator : AbstractValidator<CancelAppointmentCmd>
    {
        public CancelAppointmentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Appointment ID is required.")
                .Must(BeValidGuid).WithMessage("Invalid Appointment ID format.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}