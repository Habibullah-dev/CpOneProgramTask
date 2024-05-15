using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class ParagraphQuestion : BaseQuestion
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = "Paragraph";
    }

}
