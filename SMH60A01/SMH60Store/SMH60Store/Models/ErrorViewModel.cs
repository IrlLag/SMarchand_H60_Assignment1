namespace SMH60Store.Models
{
    public class ErrorViewModel
    {
        private string? _requestId;

        public string? RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
