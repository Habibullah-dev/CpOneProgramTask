using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class DropdownQuestion : BaseQuestion
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = "Dropdown";

        [JsonProperty(PropertyName = "choices")]
        public List<string> Choices { get; set; } = [];

        [JsonProperty(PropertyName = "isOthersEnabled")]
        public bool IsOthersEnabled { get; set; }
    }

}
