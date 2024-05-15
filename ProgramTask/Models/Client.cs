using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class Client
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "personalInfo")]
        public PersonalInfo PersonalInfo { get; set; } = new();
    }

}
