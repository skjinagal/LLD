namespace TrafficSignal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new TrafficLightController();

            var light1 = new TrafficLight();
            light1.Durations = new Dictionary<Signal, int>
            {
                { Signal.Red, 10 },
                { Signal.Yellow, 3 },
                { Signal.Green, 7 }
            };
            var road1 = new Road("Main St", light1);

            var light2 = new TrafficLight();
            light2.Durations = new Dictionary<Signal, int>
            {
                { Signal.Red, 8 },
                { Signal.Yellow, 2 },
                { Signal.Green, 6 }
            };
            var road2 = new Road("2nd Ave", light2);

            controller.AddRoad(road1);
            controller.AddRoad(road2);

            for (int t = 0; t < 30; t++)
            {
                controller.Tick(1);
                Console.WriteLine(
                    $"Time: {t + 1}s | " +
                    $"{road1.Name}: {road1.TrafficLight.CurrentSignal} ({road1.TrafficLight.TimeInCurrentSignal}s) | " +
                    $"{road2.Name}: {road2.TrafficLight.CurrentSignal} ({road2.TrafficLight.TimeInCurrentSignal}s)"
                );
            }
        }
    }
}