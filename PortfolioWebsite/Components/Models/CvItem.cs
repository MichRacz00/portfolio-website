namespace PortfolioWebsite.Components.Models;

public class CvItem
{
    public string Title { get; set; } = "";
    public string SubTitle { get; set; } = "";
    public string Location { get; set; } = "";
    public string Period { get; set; } = "";
    public List<string> BulletPoints { get; set; } = new();
}