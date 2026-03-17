namespace ParkingLot;
public record Ticket
{
    public int Id { get; init; }    
    public Vehicle Vehicle { get; init; }
    public DateTime EntryTime { get; init; }
    public ParkingSpot ParkingSpot { get; init; }
}