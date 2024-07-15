using System.Text.Json.Serialization;

namespace FluentJiraClient.Models;

public class FieldsExampleCustomField : StandardFields {
    
    [JsonPropertyName("customfield_10016")]
    public double EstimatedStoryPoints { get; set; }
}