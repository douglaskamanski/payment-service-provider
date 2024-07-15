namespace payment_service_provider.Models;

public class Response<T>
{
    public bool Success { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}
