using System.Text.Json;
using PortfolioWebsite.Components.Models;

namespace PortfolioWebsite.Components.Services;

public class CvServiceConfig : ICvService
{
    private readonly IConfiguration _configuration;
    private readonly List<CvSection> _sections;

    public CvServiceConfig(IConfiguration configuration)
    {
        var _configuration = configuration.GetSection("CV");
        
        var path = _configuration.GetValue<string>("filePath")
                   ?? throw new InvalidOperationException("CV file path is not configured.");
        
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"CV file not found: {path}");
        }
        
        var json = File.ReadAllText(path);
        using var document = JsonDocument.Parse(json);
        _sections = new List<CvSection>();

        foreach (var property in document.RootElement.EnumerateObject())
        {
            _sections.Add(new CvSection
            {
                Title = property.Name,
                TypeKey = property.Name.ToLowerInvariant(),
                Items = JsonSerializer.Deserialize<List<CvItem>>(
                            property.Value.GetRawText())
                        ?? throw new InvalidOperationException(
                            $"Failed to deserialize section '{property.Name}'.")
            });
        }
    }

    public List<CvSection> GetCvSections()
    {
        return _sections;
    }
}