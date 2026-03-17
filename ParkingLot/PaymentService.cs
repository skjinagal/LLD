namespace ParkingLot;
public class PaymentService
{
    public bool ProcessPayment(decimal dueAmount)
    {
        Console.WriteLine("Processing payment...");
        Task.Delay(2000).Wait(); // Simulate payment processing time
        Console.WriteLine("Payment successful!");
        return true;
    }
}