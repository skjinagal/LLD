namespace UrlShortener;
using System.Text;

public class Base62Encoder
{
    private const string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public string Encode(long number)
    {
        if (number == 0) return "0";

        var result = new StringBuilder();
        while (number > 0)
        {
            int remainder = (int)(number % 62);
            result.Insert(0, Base62Chars[remainder]);
            number /= 62;
        }
        return result.ToString();
    }
}