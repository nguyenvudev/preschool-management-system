// Application/Common/Models/ApiResponse.cs
namespace PreschoolManagementSystem.Application.Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        // ✅ CHỈ GIỮ LẠI 1 PHƯƠNG THỨC Success
        public static ApiResponse<T> SuccessResult(T data, string message = "")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        // ✅ CHỈ GIỮ LẠI 1 PHƯƠNG THỨC Error
        public static ApiResponse<T> ErrorResult(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default
            };
        }
    }
}