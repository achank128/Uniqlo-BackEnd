using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Uniqlo.Models.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int code, bool isSuccess, T data, string message)
        {
            this.StatusCode = code;
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Message = message;
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>(StatusCodes.Status200OK, true, data, string.Empty);
        }
        public static ApiResponse<T> Success(string message)
        {
            return new ApiResponse<T>(StatusCodes.Status200OK, true, default, message);
        }
        public static ApiResponse<T> Success(string message, T data)
        {
            return new ApiResponse<T>(StatusCodes.Status200OK, true, data, message);
        }

        public static ApiResponse<T> Failure(int code, string error)
        {
            return new ApiResponse<T>(code, false, default, error);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
