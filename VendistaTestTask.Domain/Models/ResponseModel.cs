using System.Text.Json.Serialization;

namespace VendistaTestTask.Domain.Models;

public class ResponseModel<T>
{
    [JsonPropertyName("page_number")] public int PageNumber { get; set; }

    [JsonPropertyName("items_per_page")] public int ItemsPerPage { get; set; }

    [JsonPropertyName("items_count")] public long ItemsCount { get; set; }

    public List<T>? Items { get; set; }
    public bool Success { get; set; }
}