using Newtonsoft.Json;

namespace ProgramTask.Models
{
    public class PersonalInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "firstName")]
        public ParagraphQuestion FirstName { get; set; } = new();

        [JsonProperty(PropertyName = "lastName")]
        public ParagraphQuestion LastName { get; set; } = new();

        [JsonProperty(PropertyName = "email")]
        public ParagraphQuestion Email { get; set; } = new();

        [JsonProperty(PropertyName = "phone")]
        public ParagraphQuestion Phone { get; set; } = new();

        [JsonProperty(PropertyName = "nationality")]
        public DropdownQuestion Nationality { get; set; } = new();

        [JsonProperty(PropertyName = "currentResidence")]
        public DropdownQuestion CurrentResidence { get; set; } = new();

        [JsonProperty(PropertyName = "idNumber")]
        public NumberQuestion IdNumber { get; set; } = new();

        [JsonProperty(PropertyName = "dateOfBirth")]
        public ParagraphQuestion DateOfBirth { get; set; } = new();

        [JsonProperty(PropertyName = "gender")]
        public DropdownQuestion Gender { get; set; } = new();

        [JsonProperty(PropertyName = "additionalQuestions")]

        public List<BaseQuestion> AdditionalQuestions { get; set; } = [];

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
