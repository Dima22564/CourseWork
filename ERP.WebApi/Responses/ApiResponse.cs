namespace ERP.WebApi.Responses
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApiResponse(int status, string message = null, object data = null)
        {
            Status = status;
            Message = message ?? GetDefaultMessage(status);
            Data = data;
        }

        private string GetDefaultMessage(int status)
        {
            return status switch
            {
                400 => "Bad request",
                500 => "Internal server error",
                401 => "Not Authorized",
                404 => "Not Found",
                _ => null
            };
        }
    }
}