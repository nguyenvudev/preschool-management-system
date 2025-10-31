// Application/DTOs/Common/PagedResponse.cs
using PreschoolManagementSystem.Application.Common.Models;

namespace PreschoolManagementSystem.Application.DTOs.Common
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PagedResponse() { }

        public PagedResponse(List<T> data, int page, int pageSize, int totalCount)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPrevious = page > 1;
            HasNext = page < TotalPages;
        }

        public static PagedResponse<T> Create(List<T> data, int page, int pageSize, int totalCount)
        {
            return new PagedResponse<T>(data, page, pageSize, totalCount);
        }

        public static PagedResponse<T> FromPagedList(PagedList<T> pagedList)
        {
            return new PagedResponse<T>
            {
                Data = pagedList.Data,        
                Page = pagedList.Page,          
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                HasPrevious = pagedList.HasPrevious,
                HasNext = pagedList.HasNext
            };
        }
    }
}