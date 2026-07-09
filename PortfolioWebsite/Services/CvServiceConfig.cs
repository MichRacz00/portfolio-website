using System.Text.Json;
using PortfolioWebsite.Components.Models;

namespace PortfolioWebsite.Components.Services;

public class CvServiceConfig : ICvService
{
    private readonly List<CvSection> _sections;

    public CvServiceConfig(IConfiguration configuration)
    {
        var cvConfig = configuration.GetSection("CV");
        
        var path = cvConfig.GetValue<string>("filePath")
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
            var section = new CvSection
            {
                Title = property.Name,
                TypeKey = property.Name.ToLowerInvariant()
            };
            section.DeserializeItems(property.Value.GetRawText());
            _sections.Add(section);
        }
    }

    public List<CvSection> GetCvSections()
    {
        return _sections;
    }
}