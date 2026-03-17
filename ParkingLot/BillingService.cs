namespace ParkingLot;
public class BillingService
{
    public decimal CalculateParkingFee(Ticket ticket, DateTime exitTime)
    {
        TimeSpan duration = exitTime - ticket.EntryTime;
        decimal rate = GetRate(ticket.Vehicle.GetVehicleType());
        return (decimal)duration.TotalHours * rate;
    }

    private decimal GetRate(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.TwoWheeler => 10m,
            VehicleType.FourWheeler => 20m,
            VehicleType.HeavyVehicle => 50m,
            _ => throw new ArgumentOutOfRangeException(nameof(vehicleType), "Unknown vehicle type")
        };
    }
}