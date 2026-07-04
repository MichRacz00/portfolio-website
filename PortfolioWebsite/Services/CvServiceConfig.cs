using System.Text.Json;
using System.Text.Json.Serialization;
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
        var path = _configuration
            .GetValue<string>("filePath");
        
        var json = File.ReadAllText(path);
        
        var result = JsonSerializer.Deserialize<CvRoot>(json);
        
        return result.Items;
    }
}

public class CvRoot
{
    [JsonPropertyName("items")]
    public List<CvItem> Items { get; set; } = new();
}