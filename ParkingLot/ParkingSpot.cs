using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace ParkingLot;
public class ParkingSpot
{
    private int id;
    private bool isOccupied;
    private VehicleType vehicleType;

    public ParkingSpot(int id, VehicleType vehicleType)
    {
        this.id = id;
        this.isOccupied = false;
        this.vehicleType = vehicleType;
    }

    public bool OccupySpot(Vehicle vehicle)
    {
        if (isOccupied || vehicle.GetVehicleType() != vehicleType)
        {
            return false;
        }
        isOccupied = true;
        return true;
    }

    public bool IsAvailable()
    {
        return !isOccupied;
    }

    public bool CanFitVehicle(Vehicle vehicle)
    {
        return vehicle.GetVehicleType() == vehicleType;
    }

    public bool VacateSpot()
    {
        if (!isOccupied)
        {
            return false;
        }
        isOccupied = false;
        return true;
    }

    public int GetId()
    {
        return id;
    }

}