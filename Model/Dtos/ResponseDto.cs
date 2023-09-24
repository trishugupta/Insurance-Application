namespace Insurance.Model.Dtos
{
    public class ResponseDto<T>
    {
        public string Code { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }

    }
}
