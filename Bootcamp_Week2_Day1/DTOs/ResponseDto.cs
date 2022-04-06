using System.Text.Json.Serialization;

namespace Bootcamp_Week2_Day1.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        //Json data yollanırken bu veri yollanmayacak
        [JsonIgnore]
        public int StatusCode { get; set; }
        // Static Factory Method
        public static ResponseDto<T> Success(T Data,int statusCode = 0)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = Data };
        }
        public static ResponseDto<T> Success(int statusCode = 0)
        {
            return new ResponseDto<T>{ StatusCode = statusCode, Data = default(T) };
        }
        public static ResponseDto<T> Fail(List<string> errors,int statusCode=0)
        {
            return new ResponseDto<T>{ StatusCode = statusCode, Data = default(T),Errors=errors };
        }
        public static ResponseDto<T> Fail(string error,int statusCode = 0)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = default(T), Errors = new List<string> { error } };
        }
    }
}
