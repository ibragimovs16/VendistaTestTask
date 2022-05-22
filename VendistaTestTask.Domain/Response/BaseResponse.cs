using System.Net;

namespace VendistaTestTask.Domain.Response;

public class BaseResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Description { get; set; } = string.Empty;
    public T? Data { get; set; }
}