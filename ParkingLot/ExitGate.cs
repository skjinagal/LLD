namespace ParkingLot;
public class ExitGate
{
    private ParkingLot parkingLot;
    private BillingService billingService;
    private PaymentService paymentService;

    public ExitGate(ParkingLot parkingLot, BillingService billingService, PaymentService paymentService)
    {
        this.parkingLot = parkingLot;
        this.billingService = billingService;
        this.paymentService = paymentService;
    }

    public void UnparkVehicle(int ticketId)
    {
        var ticket = parkingLot.GetTicket(ticketId);
        if (ticket == null)
        {
            Console.WriteLine("Invalid ticket ID.");
            return;
        }
        var bill = billingService.CalculateParkingFee(ticket, DateTime.Now);
        Console.WriteLine($"Parking fee for ticket {ticket.Id}: {bill}");
        if(paymentService.ProcessPayment(bill))
        {
            parkingLot.UnparkVehicle(ticket.Id);
            Console.WriteLine("Thank you for using our parking lot!");
        }
        else
        {
            Console.WriteLine("Payment failed. Please try again.");
            return;
        }
        
    }
}