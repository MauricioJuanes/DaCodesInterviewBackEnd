using Service.Data.Entities;

namespace Service.Business.Interfaces
{
    public interface IUrlManager
    {
        UrlInfo ShortenUrl(string originalUrl);
        string GetOriginalUrl(string abreviation);
    }
}
