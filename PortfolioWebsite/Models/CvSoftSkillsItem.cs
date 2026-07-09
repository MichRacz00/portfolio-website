using System.Text.Json.Serialization;

namespace PortfolioWebsite.Components.Models;

public class CvSoftSkillsItem : CvItem
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = "";
}
