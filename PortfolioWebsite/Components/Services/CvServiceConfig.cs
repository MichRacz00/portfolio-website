using System.Text.Json;
using PortfolioWebsite.Components.Models;

namespace PortfolioWebsite.Components.Services;

public class CvServiceConfig : ICvService
{
    private readonly IConfiguration _configuration;
    
    public CvServiceConfig(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("CV");
    }
    
    public List<CvItem> GetCvItems()
    {
        var filePath = _configuration
            .GetValue<string>("filePath");
        
        var path = Path.Combine(AppContext.BaseDirectory, "Data", filePath);

        if (!File.Exists(path))
            return new List<CvItem>();

        var json = File.ReadAllText(path);

        var result = JsonSerializer.Deserialize<CvRoot>(json);

        return result?.Items ?? new List<CvItem>();
    }
}

public class CvRoot
{
    public List<CvItem> Items { get; set; } = new();
}