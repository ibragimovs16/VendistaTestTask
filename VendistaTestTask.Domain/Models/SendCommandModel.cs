using System.Text.Json.Serialization;

namespace VendistaTestTask.Domain.Models;

public class SendCommandModel
{
    [JsonPropertyName("command_id")] public int CommandId { get; set; }

    [JsonPropertyName("parameter1")] public int Parameter1 { get; set; }

    [JsonPropertyName("parameter2")] public int Parameter2 { get; set; }

    [JsonPropertyName("parameter3")] public int Parameter3 { get; set; }

    [JsonPropertyName("parameter4")] public int Parameter4 { get; set; }

    [JsonPropertyName("str_parameter1")] public string? StrParameter1 { get; set; }

    [JsonPropertyName("str_parameter2")] public string? StrParameter2 { get; set; }
}