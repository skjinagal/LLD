namespace TrafficSignal
{
    public class TrafficLightController
    {
        private List<Road> roads = new List<Road>();
        public void AddRoad(Road road)
        {
            roads.Add(road);
        }
        public void ChangeRoadSignal(Road road, Signal newSignal)
        {
            road.ChangeSignal(newSignal);
        }

        public void Tick(int secondsElapsed)
        {
            foreach (var road in roads)
            {
                var trafficLight = road.TrafficLight;
                trafficLight.TimeInCurrentSignal += secondsElapsed;

                if (trafficLight.Durations.TryGetValue(trafficLight.CurrentSignal, out int duration) &&
                    trafficLight.TimeInCurrentSignal >= duration)
                {
                    // Time to change the signal
                    switch (trafficLight.CurrentSignal)
                    {
                        case Signal.Red:
                            road.ChangeSignal(Signal.Green);
                            break;
                        case Signal.Green:
                            road.ChangeSignal(Signal.Yellow);
                            break;
                        case Signal.Yellow:
                            road.ChangeSignal(Signal.Red);
                            break;
                    }
                    trafficLight.TimeInCurrentSignal = 0; // Reset timer for new signal
                }
            }
        }
    }
}