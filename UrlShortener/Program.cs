// See https://aka.ms/new-console-template for more information
using UrlShortener;
Console.WriteLine("Hello, World!");


var urlShortener = new UrlShortener.UrlShortener();
string longUrl = "https://www.example.com/some/very/long/url";
string shortUrl = urlShortener.ShortenUrl(longUrl);
Console.WriteLine($"Short URL for {longUrl} is {shortUrl}");
string retrievedLongUrl = urlShortener.GetLongUrl(shortUrl);
Console.WriteLine($"Long URL for {shortUrl} is {retrievedLongUrl}");