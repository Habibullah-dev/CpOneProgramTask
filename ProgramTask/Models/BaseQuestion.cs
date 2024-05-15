using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class BaseQuestion
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "isMandatory")]
        public bool IsMandatory { get; set; }

        [JsonProperty(PropertyName = "isHidden")]
        public bool IsHidden { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
