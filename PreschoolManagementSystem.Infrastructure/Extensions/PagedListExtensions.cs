// Infrastructure/Extensions/PagedListExtensions.cs
using Microsoft.EntityFrameworkCore;
using PreschoolManagementSystem.Application.Common.Models;

namespace PreschoolManagementSystem.Infrastructure.Extensions
{
    public static class PagedListExtensions
    {
        // ✅ EF CORE EXTENSIONS - CHỈ Ở INFRASTRUCTURE LAYER
        public static async Task<PagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source, 
            int page, 
            int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
            
            return new PagedList<T>(items, count, page, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(
            this IQueryable<T> source,
            int page,
            int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();
            
            return new PagedList<T>(items, count, page, pageSize);
        }
    }
}