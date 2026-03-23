namespace UrlShortener;

public class UrlShortener
{
    private readonly UniqueIdGenerator _idGenerator;
    private readonly Dictionary<string, string> _urlMapping;
    private readonly Dictionary<string, string> _reverseUrlMapping;

    private readonly Base62Encoder _base62Encoder;

    private const string _baseUrl = "http://short.url/";

    public UrlShortener()
    {
        _idGenerator = new UniqueIdGenerator();
        _urlMapping = new Dictionary<string, string>();
        _reverseUrlMapping = new Dictionary<string, string>();
        _base62Encoder = new Base62Encoder();
    }

    public string ShortenUrl(string longUrl)
    {
        if(longUrl == null) throw new ArgumentNullException(nameof(longUrl));
        if (_reverseUrlMapping.TryGetValue(longUrl, out var existingShortUrl))
        {
            return existingShortUrl;
        }
        long uniqueId = _idGenerator.GenerateUniqueId();


        string shortUrl = _base62Encoder.Encode(uniqueId);
        shortUrl = _baseUrl + shortUrl;
        _urlMapping[shortUrl] = longUrl;
        _reverseUrlMapping[longUrl] = shortUrl;
        return shortUrl;
    }

    public string GetLongUrl(string shortUrl)
    {
        if (_urlMapping.TryGetValue(shortUrl, out var longUrl))
        {
            return longUrl;
        }
        throw new Exception("Short URL not found.");
    }
}