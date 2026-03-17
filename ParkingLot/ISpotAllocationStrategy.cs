namespace ParkingLot;
public interface ISpotAllocationStrategy
{
    ParkingSpot GetAvailableSpot(List<Floor> floors, Vehicle vehicle);
}