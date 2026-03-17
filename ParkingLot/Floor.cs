namespace ParkingLot;
public class Floor
{
    private int floorNumber;
    private List<ParkingSpot> parkingSpots;

    public Floor(int floorNumber, List<ParkingSpot> parkingSpots)
    {
        this.floorNumber = floorNumber;
        this.parkingSpots = parkingSpots;
    }

    public int GetFloorNumber()
    {
        return floorNumber;
    }

    public List<ParkingSpot> GetParkingSpots()
    {
        return parkingSpots;
    }
}