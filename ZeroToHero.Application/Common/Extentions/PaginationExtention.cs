using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using ZeroToHero.Application.Common.Helpers;
using ZeroToHero.Application.Common.Utils;

namespace ZeroToHero.Application.Common.Extentions
{
    #pragma warning disable
    public static class PaginationExtention
    {
        public static async Task<IList<T>> ToPagedListAsync<T>(this IList<T> sourse,
                                                                PaginationParams @params)
        {
            if (@params.PageIndex == 0 || @params.PageSize == 0)
                @params = new PaginationParams(1, 10);

            var count = sourse.Count();

            var metadata = new PaginationMetadata(count, @params.PageIndex, @params.PageSize);

            HttpContextHelper.ResponseHeaders.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return sourse.Skip(@params.SkipCount())
                               .Take(@params.PageSize)
                               .ToList();
        }
    }
}
