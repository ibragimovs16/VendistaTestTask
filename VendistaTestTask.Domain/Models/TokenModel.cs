using System.Text.Json.Serialization;

namespace VendistaTestTask.Domain.Models;

public class TokenModel
{
    public string Token { get; set; } = string.Empty;

    [JsonPropertyName("owner_id")] public int OwnerId { get; set; }

    [JsonPropertyName("role_id")] public int RoleId { get; set; }

    public string Name { get; set; } = string.Empty;
}