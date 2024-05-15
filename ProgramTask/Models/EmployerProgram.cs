using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class EmployerProgram
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;

        public PersonalInfo PersonalInfo { get; set; } = new();
    }

}
