namespace ParkingLot;
public class SpotAllocationStrategy : ISpotAllocationStrategy
{
    public ParkingSpot GetAvailableSpot(List<Floor> floors, Vehicle vehicle)
    {
        foreach (var floor in floors)
        {
            foreach (var spot in floor.GetParkingSpots())
            {
                if (spot.IsAvailable() && spot.CanFitVehicle(vehicle))
                {
                    return spot;
                }
            }
        }
        return null; // No available spot found
    }
}