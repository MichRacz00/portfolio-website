using PortfolioWebsite.Components.Models;

namespace PortfolioWebsite.Components.Services;

public interface ICvService
{
    List<CvItem> GetCvItems();
}