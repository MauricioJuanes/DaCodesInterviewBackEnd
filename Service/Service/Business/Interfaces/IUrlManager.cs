using Service.Data.Entities;

namespace Service.Business.Interfaces
{
    interface IUrlManager
    {
        UrlInfo ShortenUrl(string originalUrl);
    }
}
