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
            "experience" => CvSectionType.Experience,
            "education" => CvSectionType.Education,
            "technical skills" => CvSectionType.TechnicalSkills,
            "soft skills" => CvSectionType.SoftSkills,
            _ => throw new InvalidOperationException(
                $"Unknown CV section type '{value}'.")
        };
    }
}