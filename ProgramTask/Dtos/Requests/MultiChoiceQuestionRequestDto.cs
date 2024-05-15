namespace ProgramTask.Dtos.Requests
{
    public class MultiChoiceQuestionRequestDto
    {
        public string Question { get; set; } = string.Empty;

        public bool IsMandatory { get; set; }

        public bool IsHidden { get; set; } = false;

        public int MaxChoice { get; set; }
        public List<string> Choices { get; set; } = [];

        public bool IsOthersEnabled { get; set; }

    }
}
