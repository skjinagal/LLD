namespace ParkingLot;
public class Vehicle
{
    private string licensePlate;
    private VehicleType vehicleType;

    public Vehicle(string licensePlate, VehicleType vehicleType)
    {
        this.licensePlate = licensePlate;
        this.vehicleType = vehicleType;
    }

    public string GetLicensePlate()
    {
        return licensePlate;
    }

    public VehicleType GetVehicleType()
    {
        return vehicleType;
    }
}