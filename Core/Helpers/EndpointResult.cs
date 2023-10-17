namespace Core.Helpers
{
    public class EndpointResult
    {
        public EndpointResult(bool sucess) { }
        public EndpointResult(bool success, string message = null, dynamic data = null, List<ErrorResponseObject> errors = null, dynamic metaData = null, int? totalCount = null)
        {
            Success = success;

            Data = data;

            Errors = errors;

            if (totalCount.HasValue)
            {
                TotalCount = totalCount.Value;
            }

            if (message != null)
            {
                Message = message;
            }

            MetaData = metaData;
        }

        public EndpointResult(bool success, string message)
        {
            Success = success;

            if (!string.IsNullOrEmpty(message))
            {
                Message = message;
            }
        }
        public EndpointResult(List<ErrorResponseObject> errors)
        {
            

            Errors = errors;
           
        }

        public bool Success { get; set; }
        public dynamic Data { get; set; }
        public dynamic MetaData { set; get; }
        public List<ErrorResponseObject> Errors { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }

    }
}
