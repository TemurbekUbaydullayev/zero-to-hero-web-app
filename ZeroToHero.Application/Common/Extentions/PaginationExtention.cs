﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ZeroToHero.Application.Common.Helpers;
using ZeroToHero.Application.Common.Utils;

namespace ZeroToHero.Application.Common.Extentions
{
    #pragma warning disable
    public static class PaginationExtention
    {
        public static async Task<IEnumerable<T>> ToPagedListAsync<T>(this IQueryable<T> source,
                                                                PaginationParams @params)
        {
            if (@params.PageIndex == 0 || @params.PageSize == 0)
                @params = new PaginationParams(1, 10);

            var count = await source.CountAsync();

            var metadata = new PaginationMetadata(count, @params.PageIndex, @params.PageSize);

            HttpContextHelper.ResponseHeaders.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

           return source.Skip(@params.SkipCount())
                               .Take(@params.PageSize);
        }
    }
}