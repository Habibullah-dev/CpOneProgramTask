using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class YesOrNoQuestion : BaseQuestion
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = "YesOrNo";
    }

}
