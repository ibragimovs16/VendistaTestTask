using System.Text.Json.Serialization;

namespace VendistaTestTask.Domain.Models;

public class TerminalItemModel
{
    [JsonPropertyName("terminal_id")] public int TerminalId { get; set; }

    [JsonPropertyName("command_id")] public int CommandId { get; set; }

    public int Parameter1 { get; set; }
    public int Parameter2 { get; set; }
    public int Parameter3 { get; set; }
    public int Parameter4 { get; set; }

    [JsonPropertyName("str_parameter1")] public string? StrParameter1 { get; set; }

    [JsonPropertyName("str_parameter2")] public string? StrParameter2 { get; set; }

    public int State { get; set; }

    [JsonPropertyName("state_name")] public string? StateName { get; set; }

    [JsonPropertyName("time_created")] public DateTime? TimeCreated { get; set; }

    [JsonPropertyName("time_delivered")] public DateTime? TimeDelivered { get; set; }

    public int Id { get; set; }
}