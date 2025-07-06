using Application.Interfaces;
using MediatR;

namespace Application.Features.Appointments.GetCreateAppointmentFormData
{ 
    public class GetCreateAppointmentFormDataHandler : IRequestHandler<GetCreateAppointmentFormDataQry, CreateAppointmentFormDataResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public GetCreateAppointmentFormDataHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAppointmentFormDataResponse> Handle(GetCreateAppointmentFormDataQry request, CancellationToken cancellationToken)
        {
            var barbers = await _userService.GetBarbersAsync();
            var services = await _unitOfWork.Services.GetAllAsync();

            return new CreateAppointmentFormDataResponse
            {
                Barbers = barbers.Select(b=> new BarberDto
                {
                    Id = b.Id,
                    FullName = b.FullName
                }).ToList(),
                Services = services.Select(s => new ServiceDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            };
        }
    }
}