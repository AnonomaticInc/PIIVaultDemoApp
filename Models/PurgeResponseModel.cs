namespace PIIVaultDemoApp.Models
{
    public class PurgeResponseModel
    {

        public bool Success { get; set; }
        public Error Error { get; set; }
        public bool Data { get; set; }
    }

    public class Error
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
