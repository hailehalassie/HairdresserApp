using FluentValidation;

namespace Application.Features.Appointments.UpdateStatus
{
    public class UpdateStatusValidator : AbstractValidator<UpdateStatusCmd>
    {
        public UpdateStatusValidator()
        {
            RuleFor(x => x.AppointmentId)
                .NotEmpty().WithMessage("Appointment ID is required.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid status value.");
        }
    }
 }
