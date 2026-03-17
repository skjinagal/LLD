// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using ParkingLot;
Console.WriteLine("Parking Lot System!");
var input = File.ReadAllText("input.txt");
var lines = input.Split(Environment.NewLine);
var floors = new List<Floor>();
for (int i = 1; i <= int.Parse(lines[0]); i++)
{
    int spotId = 0;
    var parkingSpots = new List<ParkingSpot>();
    var floor = new Floor(i, parkingSpots);
    for(int j = 0; j< int.Parse(lines[2]);j++)
    {
        parkingSpots.Add(new ParkingSpot(spotId++, VehicleType.TwoWheeler));
    }
    for(int j = 0; j< int.Parse(lines[3]);j++)
    {
        parkingSpots.Add(new ParkingSpot(spotId++, VehicleType.FourWheeler));
    }
    for(int j = 0; j< int.Parse(lines[4]);j++)
    {
        parkingSpots.Add(new ParkingSpot(spotId++, VehicleType.HeavyVehicle));
    }
    floors.Add(new Floor(i, parkingSpots));
}
var parkingLot = new ParkingLot.ParkingLot(floors);
parkingLot.SetSpotAllocationStrategy(new SpotAllocationStrategy());
var entryGate = new EntryGate(parkingLot);
var billingService = new BillingService();
var paymentService = new PaymentService();
var exitGate = new ExitGate(parkingLot, billingService, paymentService);
    
while (true)
{
    Console.WriteLine("Enter command (park/unpark/exit):");
    var command = Console.ReadLine();
    switch(command)
    {
        case "park":
            Console.WriteLine("Enter vehicle type (TwoWheeler/FourWheeler/HeavyVehicle):");
            var vehicleTypeInput = Console.ReadLine();
            if (Enum.TryParse<VehicleType>(vehicleTypeInput, out var vehicleType))
            {
                var vehicle = new Vehicle(GenerateLicencePlate(), vehicleType);
                var ticket = entryGate.ParkVehicle(vehicle);
                if (ticket != null)
                {
                    Console.WriteLine($"Vehicle parked. Ticket ID: {ticket.Id}");
                }
                else
                {
                    Console.WriteLine("No available spot for the vehicle.");
                }
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
            }
            break;
        case "unpark":
            Console.WriteLine("Enter ticket ID:");
            if (int.TryParse(Console.ReadLine(), out var ticketId))
            {
                exitGate.UnparkVehicle(ticketId);
                Console.WriteLine("Vehicle unparked.");
            }
            else
            {
                Console.WriteLine("Invalid ticket ID.");
            }
            break;
        case "exit":
            return;
        default:
            Console.WriteLine("Invalid command.");
            break;
    }
}

string GenerateLicencePlate() {
    Random random = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, 6)
      .Select(s => s[random.Next(s.Length)]).ToArray());
}
