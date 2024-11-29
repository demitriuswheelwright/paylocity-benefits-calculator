namespace BenefitsCalculator.Service
{
    public class ServiceResponse
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse where T : class
    {
        public T Data { get; set; }
    }
}
