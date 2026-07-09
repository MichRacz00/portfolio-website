using System.Text.Json.Serialization;

namespace PortfolioWebsite.Components.Models;

public class CvSoftSkillsItem : CvItem
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = "";
    
    [JsonPropertyName("content")]
    public string Content { get; set; } = "";
}