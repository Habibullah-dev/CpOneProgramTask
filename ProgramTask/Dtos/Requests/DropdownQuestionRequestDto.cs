namespace ProgramTask.Dtos.Requests
{
    public class DropdownQuestionRequestDto
    {
        public string Question { get; set; } = string.Empty;

        public bool IsMandatory { get; set; }

        public bool IsHidden { get; set; } = false;

        public List<string> Choices { get; set; } = [];

        public bool IsOthersEnabled { get; set; }

    }
}
