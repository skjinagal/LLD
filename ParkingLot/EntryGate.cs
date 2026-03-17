namespace ParkingLot;

public class EntryGate
{
    private ParkingLot parkingLot;

    public EntryGate(ParkingLot parkingLot)
    {
        this.parkingLot = parkingLot;
    }
    
    public Ticket ParkVehicle(Vehicle vehicle)
    {
        Ticket ticket = parkingLot.ParkVehicle(vehicle);
        if (ticket == null)
        {
            throw new Exception("No available spot for the vehicle");
        }
        return ticket;
    }
}