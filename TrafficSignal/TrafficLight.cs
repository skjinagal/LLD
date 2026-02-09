namespace TrafficSignal
{
    public class TrafficLight
    {
        public int Id { get; set; }
        public Signal CurrentSignal { get; private set; }
        public Dictionary<Signal, int> Durations { get; set; }
        public int TimeInCurrentSignal { get; set; }
        public TrafficLight()
        {
            CurrentSignal = Signal.Red; // Default signal
        }

        public void ChangeSignal(Signal newSignal)
        {
            CurrentSignal = newSignal;
        }
    }
}