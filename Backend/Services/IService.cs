public interface IBookingInitializer
{
    Task<Unit> Handle(BookingInitializationRequest request, CancellationToken cancellationToken);
}