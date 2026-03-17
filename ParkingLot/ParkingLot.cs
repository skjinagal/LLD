namespace ParkingLot;
public class ParkingLot
{
    private List<Floor> floors;
    private Dictionary<int, Ticket> activeTickets;
    private ISpotAllocationStrategy spotAllocationStrategy;
    public ParkingLot(List<Floor> floors)
    {
        this.floors = floors;
        this.activeTickets = new Dictionary<int, Ticket>();
    }

    public void SetSpotAllocationStrategy(ISpotAllocationStrategy strategy)
    {
        this.spotAllocationStrategy = strategy;
    }


    public List<Floor> GetFloors()
    {
        return floors;
    }

    public Ticket ParkVehicle(Vehicle vehicle)
    {
        var spot = spotAllocationStrategy.GetAvailableSpot(floors, vehicle);
        if (spot != null)
        {
            Console.WriteLine($"Spot allocated: Floor {spot.GetId()}");
            spot.OccupySpot(vehicle);
            var ticket = new Ticket {
                 Id = GenerateTicketId(), 
                 Vehicle = vehicle,
                  EntryTime = DateTime.Now,
                  ParkingSpot = spot };
            activeTickets[ticket.Id] = ticket;
            return ticket;
        }
        return null; // No available spot
    }

    public void UnparkVehicle(int ticketId)
    {
        if (activeTickets.TryGetValue(ticketId, out var ticket))
        {
            var vehicle = ticket.Vehicle;
            var spot = ticket.ParkingSpot;
            if (spot != null)
            {
                spot.VacateSpot();
                activeTickets.Remove(ticketId);
            }
        }
    }

    private int GenerateTicketId()
    {
        return activeTickets.Count + 1; // Simple ticket ID generation logic
    }

    public Ticket GetTicket(int ticketId)
    {
        if (activeTickets.TryGetValue(ticketId, out var ticket))
        {
            return ticket;
        }
        return null; // Ticket not found
    }
}