using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.Models
{
    public class PagedResponse<T> : ApiResponse<List<T>> where T : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public object Statistics { get; set; }

        public PagedResponse() { }

        public PagedResponse(List<T> items, int count, int pageIndex, int pageSize, object statistics)
        {
            this.StatusCode = StatusCodes.Status200OK;
            this.IsSuccess = true;
            this.Message = string.Empty;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.TotalRecords = count;
            this.Data = items;
            this.Statistics = statistics;
        }

        public static async Task<PagedResponse<T>> CreateAsync(IQueryable<T> source, int? pageIndex, int? pageSize)
        {
            if (pageSize == null || pageSize < 1) pageSize = 10;
            if (pageIndex == null || pageIndex < 1) pageIndex = 1;

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync();
            return new PagedResponse<T>(items, count, pageIndex.Value, pageSize.Value, null);
        }

        public static async Task<PagedResponse<T>> CreateStatisticAsync(IQueryable<T> source, int? pageIndex, int? pageSize, object statistics)
        {
            if (pageSize == null || pageSize < 1) pageSize = 10;
            if (pageIndex == null || pageIndex < 1) pageIndex = 1;

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync();
            return new PagedResponse<T>(items, count, pageIndex.Value, pageSize.Value, statistics);
        }
    }
}
