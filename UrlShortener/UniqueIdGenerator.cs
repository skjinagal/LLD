namespace UrlShortener;

// this is a unique id generator that generates a unique id whenever asked.
// we will replicate twitter's snowflake algorithm to generate unique ids.
// the unique id will be a 64-bit integer that is composed of the following parts:
// - 41 bits for the timestamp (in milliseconds) since a custom epoch
// - 5 bits for the datacenter id (to ensure uniqueness across multiple datacenters)
// - 5 bits for the machine id (to ensure uniqueness across multiple machines)
// - 12 bits for a sequence number (to ensure uniqueness within the same millisecond)
public class UniqueIdGenerator
{
    long _customEpoch;
    int _datacenterId;
    int _machineId;
    long _lastTimestamp;
    int _sequence;
    public UniqueIdGenerator()
    {
        _customEpoch = new DateTimeOffset(new DateTime(2020, 1, 1)).ToUnixTimeMilliseconds();
        _datacenterId = 123; // for simplicity, we will use a fixed datacenter id
        _machineId = 471; // for simplicity, we will use a fixed machine id
        _lastTimestamp = -1;
        _sequence = 0;
    }

    public long GenerateUniqueId()
    {
        long timestamp = GetCurrentTimestamp();

        if (timestamp < _lastTimestamp)
        {
            throw new Exception("Clock moved backwards. Refusing to generate id.");
        }

        if (timestamp == _lastTimestamp)
        {
            _sequence = (_sequence + 1) & 0xFFF; // 0xFFF is 4095, which is the maximum value for a 12-bit number
            if (_sequence == 0)
            {
                // sequence overflow, wait for the next millisecond
                while (GetCurrentTimestamp() <= _lastTimestamp) { }
                timestamp = GetCurrentTimestamp();
            }
        }
        else
        {
            _sequence = 0;
        }

        _lastTimestamp = timestamp;

        long uniqueId = ((timestamp - _customEpoch) << 22) | ((long)_datacenterId << 17) | ((long)_machineId << 12) | (long)_sequence;
        return uniqueId;
    }

    private long GetCurrentTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}