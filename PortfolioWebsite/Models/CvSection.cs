namespace PortfolioWebsite.Components.Models;

public enum CvSectionType
{
    Experience,
    Education,
    Skills
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
            "skills" => CvSectionType.Skills,
            _ => throw new InvalidOperationException(
                $"Unknown CV section type '{value}'.")
        };
    }
}