using System.Text.Json.Serialization;

namespace PortfolioWebsite.Components.Models;

public abstract class CvItem
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = "";
    
    [JsonPropertyName("subTitle")]
    public string SubTitle { get; set; } = "";
    
    [JsonPropertyName("location")]
    public string Location { get; set; } = "";
    
    [JsonPropertyName("period")]
    public string Period { get; set; } = "";
    
    [JsonPropertyName("bulletPoints")]
    public List<string> BulletPoints { get; set; } = new();
}