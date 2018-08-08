using Service.Business.Interfaces;
using Service.Data;
using Service.Data.Entities;
using System;
using System.Linq;

namespace Service.Business
{
    public class UrlManager : IUrlManager
    {
        public UrlInfo ShortenUrl(string originalUrl)
        {
            using (var ctx = new UrlContext())
            {
                UrlInfo url;

                url = ctx.UrlInfos.Where(u => u.OriginalUrl == originalUrl).FirstOrDefault();
                if (url != null)
                {
                    return url;
                }

                var abreviation = this.NewAbreviation();

                if (string.IsNullOrEmpty(abreviation))
                {
                    throw new ArgumentException("Could not find a abreviation");
                }

                url = new UrlInfo()
                {
                    Added = DateTime.Now,
                    OriginalUrl = originalUrl,
                    Abreviation = abreviation
                };

                ctx.UrlInfos.Add(url);

                ctx.SaveChanges();

                return url;
            }
        }

        private string NewAbreviation()
        {
            ///As time passes and abreviations are used the urls will become longer, 
            ///we could use a more complex algorithm to avoid trying shorter lenghts
            ///once they are used, but unless we have a large userbase I don't see the 
            ///need.
            using (var ctx = new UrlContext())
            {
                var maxAbreviationLength = 8;
                for (int length = 3; length < maxAbreviationLength; length++)
                {
                    int i = 0;
                    while (true)
                    {
                        string abreviation = Guid.NewGuid().ToString().Substring(0, length);
                        if (!ctx.UrlInfos.Where(u => u.Abreviation == abreviation).Any())
                        {
                            return abreviation;
                        }
                        if (i > 15)
                        {
                            break;
                        }
                        i++;
                    }
                }

                return string.Empty;
            }
        }
    }
}