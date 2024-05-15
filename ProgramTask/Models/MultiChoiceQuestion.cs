using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class MultiChoiceQuestion : BaseQuestion
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = "MultiChoice";

        [JsonProperty(PropertyName = "choices")]
        public List<string> Choices { get; set; } = [];

        [JsonProperty(PropertyName = "isOthersEnabled")]
        public bool IsOthersEnabled { get; set; }

        [JsonProperty(PropertyName = "maxChoice")]
        public int MaxChoice { get; set; }
    }

}
