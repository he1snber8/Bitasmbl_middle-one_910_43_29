namespace Project_Backend_2024.Services.CommandServices.Calendly;

public class BookingInitializer(
    IHttpContextAccessor httpContextAccessor,
    UserManager<User> userManager,
    ICalendlyBookingRepository calendlyBookingRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<BookingInitializationRequest, Unit>
{

    public async Task<Unit> Handle(BookingInitializationRequest request, CancellationToken cancellationToken)
    {
        var recruiterId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? throw new UserNotFoundException();

        var recruiter = await userManager.FindByIdAsync(recruiterId);
        var developer = await userManager.FindByIdAsync(request.InviteeDeveloperId);

        var booking = new CalendlyBooking
        {
            Recruiter = recruiter,
            Developer = developer,
            ProjectId = request.ProjectId,
            Status = CalendlyBookingStatus.Pending,
            EventType = "Booking"
        };

        calendlyBookingRepository.Insert(booking);

        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

public class BookingInitializationRequest : IRequest<Unit>
{
    public string InviteeDeveloperId { get; set; }
    public int ProjectId { get; set; }
}