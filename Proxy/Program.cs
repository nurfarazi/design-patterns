namespace Proxy;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the ProxyApiService
        var apiService = new ProxyApiService(new ApiService());

        // Fetch data from the API
        var data1 = apiService.GetData("https://api.example.com/data");
        var data2 = apiService.GetData("https://api.example.com/data");
        var data3 = apiService.GetData("https://api.example.com/data");

        Console.WriteLine(data1);
        Console.WriteLine(data2);
        Console.WriteLine(data3);
    }
}

public interface IApiService
{
    string GetData(string url);
}

public class ApiService : IApiService
{
    public string GetData(string url)
    {
        Console.WriteLine("Fetching data from the API");
        // Simulate fetching data from an external API
        return $"Data from {url} at {DateTime.Now}";
    }
}

public class ProxyApiService : IApiService
{
    private readonly IApiService _apiService;

    public ProxyApiService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public string GetData(string url)
    {
        // Check if the data is already cached
        if (Cache.Contains(url))
        {
            Console.WriteLine("Data is already cached");
            return Cache.Get(url);
        }

        // Fetch the data from the API
        var data = _apiService.GetData(url);

        // Cache the data
        Cache.Add(url, data);

        return data;
    }
}

public static class Cache
{
    private static readonly Dictionary<string, string> _cache = new();

    public static void Add(string key, string value)
    {
        _cache[key] = value;
    }

    public static string Get(string key)
    {
        return _cache[key];
    }

    public static bool Contains(string key)
    {
        return _cache.ContainsKey(key);
    }
}