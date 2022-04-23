namespace DescontroladaAPI.Models
{
    public class ReturnObjectModel
    {
        public object? Object { get; set; }

        public ErrorResponseModel[] ErrorResponse { get; set; }

        public int Status { get; set; }
    }

    public class ErrorResponseModel
    {
        public string? Message { get; set; }

        public string? InternalMessage { get; set; }
    }
}
