using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class NumberQuestion : BaseQuestion
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = "Number";
    }

}
