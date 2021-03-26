namespace BloodDonorTracker.Helper
{
    public class ResponseMessage
    {
        public ResponseMessage() { }
        public ResponseMessage(string message, bool? success = true)
        {
            Message = message;
            Success = success.Value;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}