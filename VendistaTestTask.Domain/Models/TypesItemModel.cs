using System.Text.Json.Serialization;

namespace VendistaTestTask.Domain.Models;

public class TypesItemModel
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonPropertyName("parameter_name1")] public string? ParameterName1 { get; set; }

    [JsonPropertyName("parameter_name2")] public string? ParameterName2 { get; set; }

    [JsonPropertyName("parameter_name3")] public string? ParameterName3 { get; set; }

    [JsonPropertyName("parameter_name4")] public string? ParameterName4 { get; set; }

    [JsonPropertyName("str_parameter_name1")]
    public string? StrParameterName1 { get; set; }

    [JsonPropertyName("str_parameter_name2")]
    public string? StrParameterName2 { get; set; }

    [JsonPropertyName("parameter_default_value1")]
    public int? ParameterDefaultValue1 { get; set; }

    [JsonPropertyName("parameter_default_value2")]
    public int? ParameterDefaultValue2 { get; set; }

    [JsonPropertyName("parameter_default_value3")]
    public int? ParameterDefaultValue3 { get; set; }

    [JsonPropertyName("parameter_default_value4")]
    public int? ParameterDefaultValue4 { get; set; }

    [JsonPropertyName("str_parameter_default_value1")]
    public string? StrParameterDefaultValue1 { get; set; }

    [JsonPropertyName("str_parameter_default_value2")]
    public string? StrParameterDefaultValue2 { get; set; }

    public bool Visible { get; set; }
}