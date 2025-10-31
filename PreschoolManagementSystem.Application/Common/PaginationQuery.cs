// Application/DTOs/Common/PaginationQuery.cs
namespace PreschoolManagementSystem.Application.DTOs.Common
{
    public class PaginationQuery
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        public int Page { get; set; } = 1;
        
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string? SortBy { get; set; }
        public bool SortDesc { get; set; }
        public string? Search { get; set; }
    }
}