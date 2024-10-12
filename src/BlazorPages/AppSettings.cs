using System.Text.Json.Serialization;

namespace BlazorPages;

public enum ExampleEnum
{
    None = 0,
    FirstValue = 1,
}

public class AppSettings
{
    [JsonPropertyName("stringValue")]
    public string? StringValue { get; set; }

    [JsonPropertyName("intValue")]
    public int IntValue { get; set; }

    [JsonPropertyName("enumValue")]
    public ExampleEnum EnumValue { get; set; }

    /// <summary>
    ///     This property simply demonstrates that non-existent enum values will not cause an exception during deserialization.
    ///     See <see cref="Util.UnknownEnumConverter"/>
    /// </summary>
    [JsonPropertyName("nonexistentEnumValue")]
    public ExampleEnum NonexistentEnumValue { get; set; }
}