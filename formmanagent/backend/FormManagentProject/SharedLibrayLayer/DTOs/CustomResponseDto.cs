using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharedLibrayLayer.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get;private set; }
        public int StatusCode { get;private set; }
        public ErrorDto ErrorDto { get; private set; }

        public static CustomResponseDto<T> Success(int statusCode, T Data)
        {
            return new CustomResponseDto<T> { Data = Data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {Data=default, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode,ErrorDto errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, ErrorDto = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            var message =new  ErrorDto(errors);
            return new CustomResponseDto<T> { ErrorDto =message , StatusCode = statusCode };
        }
    }
}
