namespace TrafficSignal
{
    public class Road
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrafficLight TrafficLight { get; set; }
        public Road(string name, TrafficLight trafficLight)
        {
            Name = name;
            TrafficLight = trafficLight;
        }
        public void ChangeSignal(Signal newSignal)
        {
            TrafficLight.ChangeSignal(newSignal);
        }
    }
}