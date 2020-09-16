namespace ClassificadosWeb.Api.Models
{
    public class ResponseApi
    {
        public ResponseApi() { }

        public ResponseApi(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
    }
}