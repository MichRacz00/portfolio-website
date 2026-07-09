using System.Text.Json;

namespace PortfolioWebsite.Components.Models;

public enum CvSectionType
{
    Experience,
    Education,
    TechnicalSkills,
    SoftSkills
}

public class CvSection
{
    public string Title { get; set; } = "";

    public List<CvItem> Items { get; set; } = new();

    public CvSectionType Type { get; private set; }

    public string TypeKey
    {
        set => Type = value switch
        {
            "experience"       => CvSectionType.Experience,
            "education"        => CvSectionType.Education,
            "technical skills" => CvSectionType.TechnicalSkills,
            "soft skills"      => CvSectionType.SoftSkills,
            _ => throw new InvalidOperationException(
                $"Unknown CV section type '{value}'.")
        };
    }

    public void DeserializeItems(string rawJson)
    {
        Items = Type switch
        {
            CvSectionType.Experience      => JsonSerializer.Deserialize<List<CvExperianceItem>>(rawJson)!.Cast<CvItem>().ToList(),
            CvSectionType.Education       => JsonSerializer.Deserialize<List<CvEducationItem>>(rawJson)!.Cast<CvItem>().ToList(),
            CvSectionType.TechnicalSkills => JsonSerializer.Deserialize<List<CvTechnicalSkillsItem>>(rawJson)!.Cast<CvItem>().ToList(),
            CvSectionType.SoftSkills      => JsonSerializer.Deserialize<List<CvSoftSkillsItem>>(rawJson)!.Cast<CvItem>().ToList(),
            _ => throw new InvalidOperationException(
                $"No item deserializer defined for section type '{Type}'.")
        };
    }
}